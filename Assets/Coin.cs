using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour 
{
    public AudioClip CollectCoinSFX;

    private SoundManager _soundManager;
    private GameObject _player;
    private readonly int _speed = 30;

    void Start()
    {
        _soundManager = GetComponent<SoundManager>();
    }

    void Update()
    {
        if (_player != null)
        {
            print("coin moving");
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, step);
        }    
    }

    public void Collect() {
        _soundManager.PlaySFXClip(CollectCoinSFX);
        StartCoroutine(RemoveGameObject());
	}

    public void Follow(GameObject player)
    {
        _player = player;
    }

    private IEnumerator RemoveGameObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
