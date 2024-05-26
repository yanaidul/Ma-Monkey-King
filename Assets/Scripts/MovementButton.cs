using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _isRight;
    [SerializeField] private MovementDirection _movementDirection;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isRight) _movementDirection.SetDirection(1);
        else _movementDirection.SetDirection(-1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _movementDirection.SetDirection(0);
    }

    

}
