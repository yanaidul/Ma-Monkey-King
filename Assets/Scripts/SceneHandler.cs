using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] GameEventNoParam _onNextLevelEvent;
    [SerializeField] GameEventNoParam _onOnReturnToLevel1Event;

    public void OnNextLevel()
    {
        _onNextLevelEvent.Raise();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void OnRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OnPlayLevel2Scene()
    {
        SceneManager.LoadScene(2);
    }

    public void OnPlayLevel3Scene()
    {
        SceneManager.LoadScene(3);
    }

    public void OnMainMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


    public void OnQuit()
    {
        Application.Quit();
    }
}
