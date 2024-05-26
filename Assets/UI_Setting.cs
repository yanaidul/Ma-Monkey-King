using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Setting : MonoBehaviour
{
    [SerializeField] private List<Sprite> _listOfBlueBarSprite;
    [SerializeField] private Image _sfxBlueBar;
    [SerializeField] private Image _bgmBlueBar;

    [SerializeField] private GameObject _sfxSwitchOn;
    [SerializeField] private GameObject _sfxSwitchOff;
    [SerializeField] private GameObject _bgmSwitchOn;
    [SerializeField] private GameObject _bgmSwitchOff;

    [SerializeField] private PlayerDataScriptableObject _playerData;

    private void OnEnable()
    {
        UpdateSetting();
    }

    public void UpdateSetting()
    {
        _sfxBlueBar.sprite = _listOfBlueBarSprite[_playerData.SFXVolume];
        _bgmBlueBar.sprite = _listOfBlueBarSprite[_playerData.BGMVolume];
    }
}
