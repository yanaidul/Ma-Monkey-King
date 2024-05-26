using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargetPos : MonoBehaviour
{
   [SerializeField] private List<Transform> _listOfPositions = new List<Transform>();

    public Transform ReturnRandomPosition()
    {
        int random = Random.Range(0, _listOfPositions.Count);
        return _listOfPositions[random];
    }
}
