using UnityEngine;

public class PlaneCollider : MonoBehaviour 
{
	public GameObject PlaneObject;
    public GameObject Explosion;
	void OnTriggerEnter(Collider other)
    {
		print(other + " name " + other.name);
		switch (other.tag) {
			case "Coin":
				CoinCollision(other);
				break;
			default:
				CheckUnTaggedCollision(other);
				break;
		}
    }

	// Collides with the coin, we get the script that controls 
	// the logic for the coin and call collect so it will
	// know what to do after we collide into it.
	private void CoinCollision(Collider other) {
		Coin coin = other.GetComponent<Coin>();
		coin.Collect();
		GameManager.Instance.CollectCoin();
	}

	// Check the collided object if it doesn't have a tag to see if it's
	// something we're also looking for.
	private void CheckUnTaggedCollision(Collider other) {
		if (other.name.Contains("Cube")) {
			EnemyCollision();
		}
	}

    /// Destroy the player and set the current state to the dead state.
    private void EnemyCollision()
    {
        Instantiate(Explosion, PlaneObject.transform.position, Quaternion.identity);
        Destroy(PlaneObject);
        PlayerManager.Instance.GameOver();
        GameUIManager.Instance.GameOver(gameObject);
        CameraManager.Instance.GameOver();
    }
}
