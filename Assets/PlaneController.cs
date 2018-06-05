using System;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject PlaneObject;
    public GameObject Explosion;

    private Camera _mainCamera;

	void Start () {
        _mainCamera = Camera.main;
	}
	
	void Update ()
	{
	    switch (PlayerManager.Instance.CurrentState)
	    {
            case PlayerManager.PlayerState.Alive:
                MovePlayer();
                break;
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        EnemyCollision();
    }

    /// <summary>
    /// Moves the player forward and to the side based off of where they're looking at with the cardboard.
    /// </summary>
    private void MovePlayer()
    {
        Vector3 movement = GetMoveSpeed(_mainCamera.transform.rotation.x, _mainCamera.transform.rotation.y);
        transform.position += (transform.forward + movement) / 4;
    }

    /// <summary>
    /// Creates and returns a Vector3 using rotation values from the camera that will be used for this game objects 
    /// vertical/horizontal movement
    /// </summary>
    /// <param name="x">The X rotation value of our camera, used to calculate our vertical movement (up and down)</param>
    /// <param name="y">The Y rotation value of our camera, used to calculate our horizontal movement (left and right)</param>
    /// <returns>A Vector3 that has the horizontal and vertical direction the plane should be moving to</returns>
    private Vector3 GetMoveSpeed(float x, float y)
    {
        // create our movement vector value based off of where we're looking at with a cap 
        float xMove = Mathf.Min(Mathf.Abs(y * 10), 3);
        float yMove = Mathf.Min(Mathf.Abs(x * 10), 3);

        // Figure out which direction our plane should be turning to
        if (x >= 0)
           yMove *= -1;
        if (y < 0)
            xMove *= -1;

        return new Vector3(xMove, yMove, 0f);
    }

    /// <summary>
    /// Destroy the player and set the current state to the dead state.
    /// </summary>
    private void EnemyCollision()
    {
        Instantiate(Explosion, PlaneObject.transform.position, Quaternion.identity);
        Destroy(PlaneObject);
        PlayerManager.Instance.GameOver();
        GameUIManager.Instance.GameOver(gameObject);
        CameraManager.Instance.GameOver();
    }
}
