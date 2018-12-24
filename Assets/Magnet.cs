using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour
{
    public AudioClip CollectMagnetSFX;

    private SoundManager _soundManager;

    void Start()
    {
        _soundManager = GetComponent<SoundManager>();
    }

    public void Collect()
    {
        _soundManager.PlaySFXClip(CollectMagnetSFX);
        StartCoroutine(RemoveGameObject());
    }

    private IEnumerator RemoveGameObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}