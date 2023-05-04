using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private IntEventSO _goldAddedEvent;
    [SerializeField] private IntEventSO _goldUpdateEvent;
    public int _currentGold = 0;

    private void Start()
    {
        _goldAddedEvent.Event += UpdateGold;
    }
    private void OnDestroy()
    {
        _goldAddedEvent.Event -= UpdateGold;
    }

    private void UpdateGold(int addedGold)
    {
        _currentGold += addedGold;
        _goldUpdateEvent.Invoke(_currentGold);
    }

}
