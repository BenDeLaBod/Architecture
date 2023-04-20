using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    [SerializeField] private IntEventSO _goldEvent;
    [SerializeField] private TMPro.TMP_Text _text;
    private void Start()
    {
        _goldEvent.Event += UpdateHPUI;
    }
    private void OnDestroy()
    {
        _goldEvent.Event -= UpdateHPUI;
    }
    public void UpdateHPUI(int newHPAmount) => _text.text = $"{newHPAmount}";

}
