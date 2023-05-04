using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldHUD : MonoBehaviour
{
    [SerializeField] private IntEventSO _goldEvent;
    [SerializeField] private TMPro.TMP_Text _text;

    private void Start()
    {
        _goldEvent.Event += UpdateGoldUI;
    }
    private void OnDestroy()
    {
        _goldEvent.Event -= UpdateGoldUI;
    }

    public void UpdateGoldUI(int newGoldAmount) => _text.text = $"Gold: ${newGoldAmount}";
}
