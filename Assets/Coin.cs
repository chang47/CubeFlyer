using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour 
{
    public AudioClip CollectCoinSFX;

    private SoundManager _soundManager;
    void Start()
    {
        _soundManager = GetComponent<SoundManager>();
    }

    public void Collect() {
        _soundManager.PlaySFXClip(CollectCoinSFX);
        StartCoroutine(RemoveGameObject());
	}

    private IEnumerator RemoveGameObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
