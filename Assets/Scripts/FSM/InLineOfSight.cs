using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/In Line Of Sight")]
public class InLineOfSight : Decision
{
    public override bool Decide(StateMachine stateMachine)
    {
        var enemyInLineOfSight = stateMachine.GetComponent<SightSensor>();
        return enemyInLineOfSight.Ping();
    }
}
