using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvasController : MonoBehaviour {

	void Start ()
    {
		// gameObject.SetActive(false);
	}

    /// <summary>
    /// Enables the canvas in the game 
    /// </summary>
    public void Show()
    {
//        gameObject.SetActive(true);
    }

    /// <summary>
    /// Event callback for when the player clicks on the Restart Button in the menu
    /// </summary>
    public void ClickRestartButton()
    {
        print("clicked the button");
        SceneManager.LoadScene(0);
    }
}
