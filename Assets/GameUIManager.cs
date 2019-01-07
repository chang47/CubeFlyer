using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;
    public GameObject GameOverCanvas;
    public Text ScoreText;
    public Text CoinText;

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
    }

    /// <summary>
    /// Sets the GameOverUIManager to be in the game over state.
    /// </summary>
    public void GameOver(GameObject player)
    {
        GameObject gameOverCanvas = Instantiate(GameOverCanvas, player.transform.position, Quaternion.identity);
        GameOverCanvasController gameOverController = gameOverCanvas.GetComponent<GameOverCanvasController>();
        if (gameOverController != null)
        {
            gameOverController.GameOver();
        }
    }

    public void SetCoinText(int value)
    {
        CoinText.text = "Coin: " + value;
    }

    public void SetScoreText(int value)
    {
        ScoreText.text = "Score: " + value;
    }
}
