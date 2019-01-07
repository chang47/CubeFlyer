using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;

    private float _score = 0;

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
        _score = 0;
    }

    void Update()
    {
        // increase our score and then update our ScoreText UI.
        float increaseTime = Time.deltaTime * 10;
        if (PlayerManager.Instance.ContainsPowerUp(PlayerManager.PowerUpType.Score))
        {
            increaseTime *= PowerUpsDatabase.MultiplierPowerUps[DataManager.LoadMultiplierLevel()].Effect;
        }
        _score += increaseTime;
        GameUIManager.Instance.SetScoreText((int)_score);
    }

    public int GetScore()
    {
        return (int) _score;
    }
}
