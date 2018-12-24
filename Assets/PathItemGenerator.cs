using UnityEngine;

public class PathItemGenerator : MonoBehaviour {
    public float PowerupSpawnRate = 1f; // from 0 to 1

	private string containerString = "Container";
	private string spawnPointString = "Spawn Points"; // string to find our Spawn Points container
    private string powerupSpawnPointString = "Powerup Spawn Points"; // string to find our powerup spawn points container
	private int numberOfCoinsToGenerate = 5;
	private int coinDistanceGap = 20;

	void Start () {
        SpawnCoin();
        SpawnPowerUp();
	}

    private void SpawnCoin()
    {
        Transform spawnPoint = PickSpawnPoint(containerString, spawnPointString);
        // We then create a loop of X items that are Y units apart from each other
        for (int i = 0; i < numberOfCoinsToGenerate; i++)
        {
            Vector3 newPosition = spawnPoint.transform.position;
            newPosition.z += i * coinDistanceGap;
            Instantiate(ItemLoaderManager.Instance.Coin, newPosition, Quaternion.identity);
        }
    }

    private void SpawnPowerUp()
    {
        // We randomly generate a number and divide it by 100. If it is lower than the spawn rate chance we set,
        // then we create the powerup.
        bool generatePowerUp = Random.Range(0, 100) / 100f < PowerupSpawnRate;
        if (generatePowerUp)
        {
            // Get our spawn point and its position.
            Transform spawnPoint = PickSpawnPoint(containerString, powerupSpawnPointString);
            Vector3 newPosition = spawnPoint.transform.position;

            // Get our Power-ups and randomly pick one of them to show
            GameObject[] powerUps = ItemLoaderManager.Instance.PowerUps;
            int powerUpIndex = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[powerUpIndex], newPosition, Quaternion.identity);
        }
    }

    private Transform PickSpawnPoint(string spawnPointContainerString, string spawnPointString) 
    {
        // We get container game object and then  the spawnPointContainer and get it's children which
        // are all spawn points to create a spawn point. The benefit of this is so that we don't have
        // to manually attach any game objects to the script, however we're more likely to have our code break
        // if we were to rename or restructure the spawn points
        Transform container = transform.Find(spawnPointContainerString);
        Transform spawnPointContainer = container.Find(spawnPointString);

        // Initially I first used GetComponentsInChildren, however it turns out that the function is
        // poorly named and for some reason that also includes the parent component, ie the spawnPointContainer. 
        Transform[] spawnPoints = new Transform[spawnPointContainer.childCount];

        for (int i = 0; i < spawnPointContainer.childCount; i++)
        {
            spawnPoints[i] = spawnPointContainer.GetChild(i);
        }

        // If we don't have any spawn points the rest of our code will crash, let's just leave a message
        // and quietly return
        if (spawnPoints.Length == 0)
        {
            Debug.Log("We have a path has no spawn points!");
        }

        // We randomly pick one of our spawn points to use
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }
}
