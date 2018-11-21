using UnityEngine;

public class SoundManager : MonoBehaviour {
    private AudioSource _sfxSource;
    private AudioSource _bgmSource;

    void Awake()
    {
        _sfxSource = gameObject.AddComponent<AudioSource>();
        _bgmSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBackgroundClip(AudioClip audioClip)
    {
        _bgmSource.clip = audioClip;
        _bgmSource.Play();
    }

    public void StopBackgroundClip()
    {
        if (_bgmSource.isPlaying)
        {
            _bgmSource.Stop();
        }
    }

    public void PlaySFXClip(AudioClip audioClip)
    {
        _sfxSource.PlayOneShot(audioClip);
    }
}
