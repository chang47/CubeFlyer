using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] Path;
    public GameObject Player;

    private float _spawnTriggerDistance;
    private float _spawnPointDistance;
    
	void Start ()
	{
	    _spawnTriggerDistance = 0;
	    _spawnPointDistance = 25 * 10; // Our starting path is always the same, so we know that the next point to spawn is scale * 10
	}
	
	void Update () {
	    if (Player.transform.position.z >= _spawnTriggerDistance)
	    {
	        CreateNewPath();
	    }
	}

    /// <summary>
    /// Create a new Path game object for the player to pass through
    /// </summary>
    private void CreateNewPath()
    {
        GameObject path = Instantiate(GetRandomPath(), new Vector3(0, -5, _spawnPointDistance), Quaternion.identity); // creates our new path
        _spawnTriggerDistance = path.transform.position.z; // the z position is actually the halfway point of our object
        _spawnPointDistance += path.transform.localScale.z * 10; // calculates the next point to create the game object
    }

    /// <summary>
    /// Returns a random path from our list of paths to instantiate
    /// </summary>
    private GameObject GetRandomPath()
    {
        int randomIndex = Random.Range(0, Path.Length);
        return Path[randomIndex];
    }
}
