using UnityEngine;

public class GameManager : MonoBehaviour
{
    // TODO note to self you need to add back in the game state logic that we had to stop counting score


    public static GameManager Instance;
    private int _coin = 0;
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
    

    private void Init() {
        Instance = this;
        _coin = 0;
    }

    // Called from outside function for when the player collects a coin.
    public void CollectCoin()
    {
        _coin++;
    }

    // Return the number of coins that we have collected.
    public int GetCoin() 
    {
        return _coin;
    }
}
