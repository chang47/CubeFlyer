using UnityEngine;

public class PlaneCollider : MonoBehaviour 
{
	public GameObject PlaneObject;
    public GameObject Explosion;
    public AudioClip MagnetSFX;
    public GameObject MagnetParticleEffect;
    public AudioClip MultiplierSFX;
    public GameObject MultiplierParticleEffect;
    public AudioClip InvincibleSFX;

    private SoundManager _soundManager;
    private GameObject _currentParticleEffect;

    void Start()
    {
        _soundManager = GetComponent<SoundManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            default:
                CheckUnTaggedCollision(other.gameObject);
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
		switch (other.tag) {
			case "Coin":
				CoinCollision(other);
				break;
            case "Magnet":
                MagnetCollision(other);
                break;
            case "Score":
                ScoreColllision(other);
                break;
            case "Invincible":
                InvincibleCollision(other);
                break;
		}
    }

    // Stops and gets rid of the current particle effect
    public void StopParticleEffect()
    {
        if (_currentParticleEffect != null)
        {
            ParticleSystem particleSystem = _currentParticleEffect.GetComponent<ParticleSystem>();
            particleSystem.Stop();
            Destroy(_currentParticleEffect);
            _currentParticleEffect = null;
        }
    }

	// Collides with the coin, we get the script that controls 
	// the logic for the coin and call collect so it will
	// know what to do after we collide into it.
	private void CoinCollision(Collider other) {
		Coin coin = other.GetComponent<Coin>();
		coin.Collect();
		GameManager.Instance.CollectCoin();
	}

    // Collides with the magnet, we add the power up to our list of power-ups
    // and let the power-up destroy itself from the game.
    private void MagnetCollision(Collider other)
    {
        Debug.Log("magnet collision hit");
        PlayerManager.Instance.AddPowerUp(PlayerManager.PowerUpType.Magnet);
        Magnet magnet = other.GetComponent<Magnet>();
        _soundManager.PlayBackgroundClip(MagnetSFX);
        StopParticleEffect();
        _currentParticleEffect = Instantiate(MagnetParticleEffect, PlaneObject.transform);
        ParticleSystem particleSystem = _currentParticleEffect.GetComponent<ParticleSystem>();
        particleSystem.Play();
        magnet.Collect();
    }

    // Collides with the score multiplier, we add the power up to our list of power-ups
    // and let the power-up destroy itself from the game.
    private void ScoreColllision(Collider other)
    {
        Debug.Log("score collision hit");
        PlayerManager.Instance.AddPowerUp(PlayerManager.PowerUpType.Score);
        ScoreMultiplier score = other.GetComponent<ScoreMultiplier>();
        score.Collect();
        _soundManager.PlayBackgroundClip(MultiplierSFX);
        StopParticleEffect();
        _currentParticleEffect = Instantiate(MultiplierParticleEffect, PlaneObject.transform);
    }

    private void InvincibleCollision(Collider other) {
        Debug.Log("invincible collision hit");
        PlayerManager.Instance.AddPowerUp(PlayerManager.PowerUpType.Invincible);
        Invincible invincible = other.GetComponent<Invincible>();
        invincible.Collect();
        _soundManager.PlayBackgroundClip(InvincibleSFX);
        CameraManager.Instance.AddPostProcessing();
    }

    // Check the collided object if it doesn't have a tag to see if it's
    // something we're also looking for.
    private void CheckUnTaggedCollision(GameObject other) {
		if (other.name.Contains("Cube")) {
			EnemyCollision();
		}
	}

    /// Destroy the player and set the current state to the dead state.
    private void EnemyCollision()
    {
        if (!PlayerManager.Instance.ContainsPowerUp(PlayerManager.PowerUpType.Invincible))
        {
            Instantiate(Explosion, PlaneObject.transform.position, Quaternion.identity);
            Destroy(PlaneObject);
            GameManager.Instance.GameOver();
            PlayerManager.Instance.GameOver();
            GameUIManager.Instance.GameOver(gameObject);
            CameraManager.Instance.GameOver();
        }
    }
}
