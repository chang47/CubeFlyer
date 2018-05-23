using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public Camera GameOverCamera;

    private Camera _mainCamera;

    void Start()
    {
        if (Instance != null)
        {
            // If Instance already exists, we should get rid of this game object
            // and use the original game object that set Instance   
            Destroy(gameObject);
            return;
        }

        // If Instance doesn't exist, we initialize the Player Manager
        Init();
    }

    private void Init()
    {
        Instance = this;
        _mainCamera = Camera.main;
        _mainCamera.gameObject.SetActive(true);
        GameOverCamera.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        _mainCamera.gameObject.SetActive(false);
        GameOverCamera.gameObject.SetActive(true);
    }
}
