using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageSelection : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [SerializeField] private List<Button> _stageSelectionButtons = new();

    private void Start()
    {
        foreach (var button in _stageSelectionButtons)
        {
            button.interactable = false;
        }

        _stageSelectionButtons[0].interactable = true;

        if (_playerData.UnlockedLevel > 1)
        {
            _stageSelectionButtons[1].interactable = true;
            _stageSelectionButtons[1].transform.GetChild(0).gameObject.SetActive(false);
        }

        if (_playerData.UnlockedLevel > 2)
        {
            _stageSelectionButtons[2].interactable = true;
            _stageSelectionButtons[2].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
