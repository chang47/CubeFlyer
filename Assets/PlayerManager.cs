using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public enum PlayerState { Alive, Dead }

    public PlayerState CurrentState
    {
        // I chose to be explicit, but we could also have done:
        // get; private set;
        // read more: https://stackoverflow.com/questions/3847832/understanding-private-setters
        get { return _currentState; }
        private set { _currentState = value; }
    }

    private PlayerState _currentState;

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
        CurrentState = PlayerState.Alive;
    }

    /// <summary>
    /// Sets the PlayerManager to be in the game over state.
    /// </summary>
    public void GameOver()
    {
        CurrentState = PlayerState.Dead;
    }
}
