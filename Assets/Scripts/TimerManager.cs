using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI _timerTextVictory;
    public TextMeshProUGUI _timerTextLose;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(_timer / 60F);
        int seconds = Mathf.FloorToInt(_timer % 60F);

        _timerTextVictory.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        _timerTextLose.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
