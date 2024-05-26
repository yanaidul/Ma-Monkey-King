using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class HealthOnCollision : MonoBehaviour
{
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onCollectHealthCollectibleEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!collision.TryGetComponent(out PlayerHealth playerHealth)) return;
            _onCollectHealthCollectibleEvent.Raise();
            SFXHandler.GetInstance().PlayCollectbleSFX();
            gameObject.SetActive(false);
        }
        
    }
}
