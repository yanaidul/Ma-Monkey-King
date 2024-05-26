using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

[RequireComponent(typeof(BoxCollider2D))]
public class Gate : MonoBehaviour
{
    [BoxGroup("Transform Reference")]
    [SerializeField] private Transform _gate, _finalPos;
    private Vector3 _initPos;

    private void Start()
    {
        _initPos = _gate.transform.position;
    }

    public void OnGateClosed()
    {
        if (!TryGetComponent(out BoxCollider2D collider)) return;
        collider.enabled = true;
        _gate.DOMoveY(_finalPos.position.y, 0.2f);
    }
    public void OnGateOpen()
    {
        if (!TryGetComponent(out BoxCollider2D collider)) return;
        collider.enabled = false;
        _gate.DOMoveY(_initPos.y, 0.2f);
    }

}
