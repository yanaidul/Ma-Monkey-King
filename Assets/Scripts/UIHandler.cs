using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class UIHandler : MonoBehaviour
{
    [BoxGroup("UI Reference")]
    [SerializeField] private GameObject _victoryUI, _gameoverUI,_pauseUI,_settingUI;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void DisableAllUI()
    {
        _victoryUI.SetActive(false);
        _gameoverUI.SetActive(false);
        _pauseUI.SetActive(false);
        _settingUI.SetActive(false);
    }

    public void OnVictoryUI()
    {
        DisableAllUI();
        _victoryUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnGameOverUI()
    {
        DisableAllUI();
        _gameoverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnPauseUI()
    {
        DisableAllUI();
        _pauseUI.SetActive(true);
        Time.timeScale = 0;

    }

    public void OnSettingUI()
    {
        DisableAllUI();
        _settingUI.SetActive(true);
        Time.timeScale = 0;

    }

    public void OnResume()
    {
        DisableAllUI();
        Time.timeScale = 1;

    }

}
