using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverCanvasController : MonoBehaviour {
    public Text HighScoreText;
    public Text ScoreText;
    public Text CoinText;

    /// <summary>
    /// Event callback for when the player clicks on the Restart Button in the menu
    /// </summary>
    public void ClickRestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickShopButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        HighScoreText.text = "High Score: " + DataManager.LoadScore();
        ScoreText.text = "Score: " + ScoreManager.Instance.GetScore();
        CoinText.text = "Coin: " + GameManager.Instance.GetCoin();
    }
}
