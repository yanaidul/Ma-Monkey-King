using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [SerializeField] private GameEventNoParam _onUpdateSettingBlueBar;

    private void Awake()
    {
        _playerData.TotalScore = 0;
        _playerData.SFXVolume = 4;
        _playerData.BGMVolume = 4;
        _playerData.SetIsSFXOffValue(false);
        _playerData.SetIsBGMOffValue(false);
        _onUpdateSettingBlueBar.Raise();
    }

    public void OnClickSFXSwitch(bool value)
    {
        _playerData.SetIsSFXOffValue(value);
    }

    public void OnClickBGMSwitch(bool value)
    {
        _playerData.SetIsBGMOffValue(value);
        if(value) BGM.GetInstance().PauseBGM();
        else BGM.GetInstance().PlayBGM();
    }

    public void OnClickChangeSFXVolume(bool isIncrease)
    {
        if(isIncrease) _playerData.SFXVolume += 1;
        else _playerData.SFXVolume -= 1;
        _onUpdateSettingBlueBar.Raise();
    }
    public void OnClickChangeBGMVolume(bool isIncrease)
    {
        if (isIncrease) _playerData.BGMVolume += 1;
        else _playerData.BGMVolume -= 1;
        _onUpdateSettingBlueBar.Raise();
        BGM.GetInstance().SetBGMVolume((float)_playerData.BGMVolume/10);
    }
}
