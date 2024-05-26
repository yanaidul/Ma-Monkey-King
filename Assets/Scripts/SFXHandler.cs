using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(AudioSource))]
public class SFXHandler : Singleton<SFXHandler>
{
    [BoxGroup("AudioClip")]
    [SerializeField] private AudioClip _attackSFX,_jumpSFX,_deathSFX,_collectibleSFX ;
    [BoxGroup("AudioSource")]
    [SerializeField] private AudioSource _audioSource;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    public void PlayAttackSFX()
    {
        if (_playerData.IsSFXOff) return;
        _audioSource.PlayOneShot(_attackSFX, _playerData.SFXVolume);
    }

    public void PlayJumpSFX()
    {
        if (_playerData.IsSFXOff) return;
        _audioSource.PlayOneShot(_jumpSFX, _playerData.SFXVolume);
    }

    public void PlayDeathSFX()
    {
        if (_playerData.IsSFXOff) return;
        _audioSource.PlayOneShot(_deathSFX, _playerData.SFXVolume);
    }

    public void PlayCollectbleSFX()
    {
        if (_playerData.IsSFXOff) return;
        _audioSource.PlayOneShot(_collectibleSFX, _playerData.SFXVolume);
    }

}
