using UnityEngine;

public class ItemLoaderManager : MonoBehaviour {
	public static ItemLoaderManager Instance;
	public GameObject Coin;
    public GameObject[] PowerUps;

    void Start ()
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
    }
}
