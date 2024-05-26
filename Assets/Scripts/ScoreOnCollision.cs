using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ScoreOnCollision : MonoBehaviour
{
    [BoxGroup("Event")]
    [SerializeField] private GameEvent _onCollectScoreEvent;
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onCollectCollectiblesEvent;
    [BoxGroup("Variable")]
    [SerializeField] private int _scoreValue = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _onCollectScoreEvent.Raise(this, _scoreValue);
            SFXHandler.GetInstance().PlayCollectbleSFX();
            _onCollectCollectiblesEvent.Raise();
            gameObject.SetActive(false);
        }
    }
}
