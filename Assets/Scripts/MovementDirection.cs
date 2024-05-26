using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDirection : MonoBehaviour
{
    private int _direction;


    public void SetDirection(int newDirection)
    {
        _direction = newDirection;
    }

    public int GetDirection()
    {
        return _direction;
    }
}
