using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarResultHandler : MonoBehaviour
{
    [SerializeField] private List<Image> _stars = new();
    [SerializeField] private Sprite _starFill;
    [SerializeField] private Sprite _starBlank;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    public void OnEnable()
    {
        int _currentScore = _playerData.TotalScore;

        foreach (Image star in _stars)
        {
            star.sprite = _starBlank;
        }

        if (_currentScore >= 25) _stars[0].sprite = _starFill;
        if (_currentScore >= 40) _stars[1].sprite = _starFill;
        if (_currentScore >= 50) _stars[2].sprite = _starFill;
    }

}
