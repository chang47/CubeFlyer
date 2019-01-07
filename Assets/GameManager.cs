using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        int scoreIncrease = 1;
        if (PlayerManager.Instance.ContainsPowerUp(PlayerManager.PowerUpType.Score))
        {
            scoreIncrease *= (int) PowerUpsDatabase.MultiplierPowerUps[DataManager.LoadMultiplierLevel()].Effect;
        }
        _coin += scoreIncrease;
        GameUIManager.Instance.SetCoinText(_coin);
    }

    // Return the number of coins that we have collected.
    public int GetCoin() 
    {
        return _coin;
    }

    public void GameOver()
    {
        DataManager.AddCoin(_coin);
        DataManager.AddNewScore(ScoreManager.Instance.GetScore());
    }
}
