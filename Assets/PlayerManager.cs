using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public enum PlayerState { Alive, Dead }
    public GameObject Player;
    public GameObject MagnetCollider;

    public enum PowerUpType { Magnet }
    private Dictionary<PowerUpType, PowerUp> powerUpDictionary;
    private float powerUpDuration = 30f;
    private List<PowerUpType> itemsToRemove;

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

    void Update()
    {
        foreach (KeyValuePair<PowerUpType, PowerUp> entry in powerUpDictionary)
        {
            entry.Value.Duration -= Time.deltaTime;

            // We can't remove an item from a dictionary if we're iterating through it.
            // Instead we have to keep track of it in a list and then remove the items from the
            // dictionary later.
            if (entry.Value.Duration <= 0)
            {
                itemsToRemove.Add(entry.Key);
            }
        }

        // Go thorugh all of the power ups that needs to be removed and remove it from the 
        // dictionary.
        foreach (PowerUpType powerUpType in itemsToRemove)
        {
            switch (powerUpType)
            {
                case PowerUpType.Magnet:
                    Transform magnetCollider = Player.transform.Find("Magnet Collider(Clone)");
                    print(magnetCollider);
                    Destroy(magnetCollider.gameObject);
                    magnetCollider = null;
                    break;

            }
            powerUpDictionary.Remove(powerUpType);
        }

        // We've removed everything, let's clear our list.
        itemsToRemove.Clear();

        // If we no longer have any power-ups active, let's stop playing our background music
        if (powerUpDictionary.Count == 0)
        {
            Player.GetComponent<SoundManager>().StopBackgroundClip();
            Player.GetComponent<PlaneCollider>().StopParticleEffect();
        }
    }

    private void Init()
    {
        Instance = this;
        CurrentState = PlayerState.Alive;

        // Create an empty dictionary and list, otherwise they'll be null later when we
        // try to access them and crash.
        powerUpDictionary = new Dictionary<PowerUpType, PowerUp>();
        itemsToRemove = new List<PowerUpType>();
    }

    /// <summary>
    /// Sets the PlayerManager to be in the game over state.
    /// </summary>
    public void GameOver()
    {
        CurrentState = PlayerState.Dead;
    }

    public void AddPowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.Magnet:
                // if we already have the MagnetCollider, don't add it again.
                if (powerUpDictionary.ContainsKey(powerUpType))
                {
                    break;
                }
                // We add the Magnet Collider to our player.
                Instantiate(MagnetCollider, Player.transform.position, Quaternion.identity, Player.transform);
                break;
        }
        // An interesting part of this is that if we get another power up that if we
        // get a duplicate power up, we will replace it with the new one.
        powerUpDictionary[powerUpType] = new PowerUp(powerUpDuration);
    }

    /// <summary>
    /// See if the player currently have the power up that we pass in.
    /// </summary>
    public bool ContainsPowerUp(PowerUpType powerUpType)
    {
        return powerUpDictionary.ContainsKey(powerUpType);
    }
}
