using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntEventSO : ScriptableObject
{
    //Event
    public event Action<int> Event;

    //Function for invoking the event
    public void Invoke(int value) => Event?.Invoke(value);
    
}
