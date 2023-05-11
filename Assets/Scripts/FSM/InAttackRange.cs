using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/In Attack Range")]

public class InAttackRange : Decision
{
    public override bool Decide(StateMachine stateMachine)  
    {
        var playerInAttackRange = stateMachine.GetComponent<SightSensor>();
        return playerInAttackRange.DistanceCheck();
    }
}
