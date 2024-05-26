using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData",menuName = "ScriptableObject/PlayerDataScriptableObject")]
[Serializable]
public class PlayerDataScriptableObject : ScriptableObject
{

    [SerializeField] private int _totalScore;
    public int TotalScore
    {
        get
        {
            return _totalScore;
        }

        set
        {
            _totalScore = value;
            if (_totalScore <= 0) _totalScore = 0;
        }
    }


    [SerializeField] private int _unlockedLevel;
    public int UnlockedLevel
    {
        get
        {
            return _unlockedLevel;
        }

        set
        {
            _unlockedLevel = value;
            if (_unlockedLevel <= 1) _unlockedLevel = 1;
            if (_unlockedLevel > 3) _unlockedLevel = 3;
        }
    }

    [SerializeField] private int _sfxVolume;
    public int SFXVolume
    {
        get
        {
            return _sfxVolume;
        }

        set
        {
            _sfxVolume = value;
            if (_sfxVolume <= 0) _sfxVolume = 0;
            if (_sfxVolume > 8) _sfxVolume = 8;
        }
    }

    [SerializeField] private int _bgmVolume;
    public int BGMVolume
    {
        get
        {
            return _bgmVolume;
        }

        set
        {
            _bgmVolume = value;
            if (_bgmVolume <= 0) _bgmVolume = 0;
            if (_bgmVolume > 8) _bgmVolume = 8;
        }
    }

    [SerializeField] private bool _isSFXOff = false;
    public bool IsSFXOff
    {
        get 
        {
            return _isSFXOff; 
        }
    }

    [SerializeField] private bool _isBGMOff = false;
    public bool IsBGMOff
    {
        get
        {
            return _isBGMOff;
        }
    }

    public void SetIsSFXOffValue(bool value)
    {
        _isSFXOff = value;
    }

    public void SetIsBGMOffValue(bool value)
    {
        _isBGMOff = value;
    }

}
