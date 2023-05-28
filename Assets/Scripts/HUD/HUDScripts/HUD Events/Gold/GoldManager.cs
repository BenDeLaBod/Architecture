using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private IntEventSO _goldAddedEvent;
    [SerializeField] private IntEventSO _goldUpdateEvent;
    public int currentGold = 0;
    private bool addGold;

    private void Start()
    {
        _goldAddedEvent.Event += UpdateGold;
        addGold = true;
    }
    private void OnDestroy()
    {
        _goldAddedEvent.Event -= UpdateGold;
    }

    private void UpdateGold(int addedGold)
    {
        if (addGold)
        {
            addGold = false;
            currentGold += addedGold;
            _goldUpdateEvent.Invoke(currentGold);
           
        }
        
    }

}
