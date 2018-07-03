using UnityEngine;

public class PathItemGenerator : MonoBehaviour {
	private string containerString = "Container";
	private string spawnPointString = "Spawn Points"; // string to find our Spawn Points container
	private int numberOfCoinsToGenerate = 5;
	private int coinDistanceGap = 20;

	void Start () {
		// We get container game object and then  the spawnPointContainer and get it's children which
		// are all spawn points to create a spawn point. The benefit of this is so that we don't have
		// to manually attach any game objects to the script, however we're more likely to have our code break
		// if we were to rename or restructure the spawn points
		Transform container = transform.Find(containerString);  
		Transform spawnPointContainer = container.Find(spawnPointString);

		// Initially I first used GetComponentsInChildren, however it turns out that the function is
		// poorly named and for some reason that also includes the parent component, ie the spawnPointContainer. 
		Transform[] spawnPoints = new Transform[spawnPointContainer.childCount];

		for (int i = 0; i < spawnPointContainer.childCount; i++) {
			spawnPoints[i] = spawnPointContainer.GetChild(i);
		}

		// If we don't have any spawn points the rest of our code will crash, let's just leave a message
		// and quietly return
		if (spawnPoints.Length == 0) {
			Debug.Log("We have a path has no spawn points!");
			return;
		}

		// We randomly pick one of our spawn points to use
		int index = Random.Range(0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints[index];
		// We then create a loop of X items that are Y units apart from each other
		for (int i = 0; i < numberOfCoinsToGenerate; i++) {
			Vector3 newPosition = spawnPoint.transform.position;
			newPosition.z += i * coinDistanceGap;
			Instantiate(ItemLoaderManager.Instance.Coin, newPosition, Quaternion.identity);
		}
	}
}
