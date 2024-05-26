using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    [BoxGroup("Transform Reference")]
    [SerializeField] private Transform _mainCam,_bg1, _bg2;
    [BoxGroup("Variables")]
    [SerializeField] private float _length;

    private Transform temp;

    private void Update()
    {

        if(_mainCam.position.x > _bg1.position.x)
        {
            _bg2.position = _bg1.position + Vector3.right * _length;
        }

        if (_mainCam.position.x < _bg1.position.x)
        {
            _bg2.position = _bg1.position + Vector3.left * _length;
        }

        if(_mainCam.position.x > _bg2.position.x || _mainCam.position.x < _bg2.position.x)
        {
            temp = _bg1;
            _bg1 = _bg2;
            _bg2 = temp;
        }
    }
}
