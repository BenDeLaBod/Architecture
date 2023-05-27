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
        //Listens to event
        _goldAddedEvent.Event += UpdateGold;
        addGold = true;
    }


    //Trigger when an event is Invoked
    private void UpdateGold(int addedGold)
    {
        if (addGold)
        {
            addGold = false;
            currentGold += addedGold;
            //Send message using the event
            _goldUpdateEvent.Invoke(currentGold);
           
        }
        
    }

}
