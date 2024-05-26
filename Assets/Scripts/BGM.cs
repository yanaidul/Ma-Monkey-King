using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BGM : Singleton<BGM>
{
    [BoxGroup("Audioclip Reference")]
    [SerializeField] private AudioClip _bgmClip;
    [BoxGroup("AudioSource Reference")]
    [SerializeField] private AudioSource _bgmSource;
    [BoxGroup("Variables")]
    [SerializeField] private float _bgmVolume;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    private void Start()
    {
        _bgmSource.clip = _bgmClip;
        _bgmSource.loop = true;
        SetBGMVolume((float)_playerData.SFXVolume/10);
        if (_playerData.IsBGMOff) return;
        PlayBGM();
    }


    public void SetBGMVolume(float volume)
    {
        _bgmSource.volume = volume;
    }

    public void PauseBGM()
    {
        _bgmSource.Pause();
    }

    public void PlayBGM()
    {
        _bgmSource.Play();
    }

    public void UnpauseBGM()
    {

        _bgmSource.UnPause();
    }

    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    public void DestroyBGMGameObject()
    {
        Destroy(gameObject);
    }
}