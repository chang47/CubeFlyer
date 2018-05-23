using UnityEngine;

/// <summary>
/// Class that is used to help us store our path so that the Unity inspector will show 2D arrays
/// </summary>
[System.Serializable]
public class Paths
{
    public GameObject[] PathVariations;
}

public class PathGeneratorComplex : MonoBehaviour
{
    public Paths[] Paths;
    
    public GameObject Player;

    private float _spawnTriggerDistance;
    private float _spawnPointDistance;

    void Start()
    {
        _spawnTriggerDistance = 0;
        _spawnPointDistance = 500; // Scaling with cubes are different than planes, instead of multiple of 10, it's just multiple of 1
    }

    void Update()
    {
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
        _spawnPointDistance += 500; // we hard coded the distance, we can attach a script to each game object to figure out the scale of each path
    }

    /// <summary>
    /// Returns a random path from our list of paths and their variations.
    /// </summary>
    private GameObject GetRandomPath()
    {
        int randomPath = Random.Range(0, Paths.Length);
        int randomVariation = Random.Range(0, Paths[randomPath].PathVariations.Length);
        return Paths[randomPath].PathVariations[randomVariation];
    }
}
