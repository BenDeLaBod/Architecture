using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Out Of Health")]
public class IsOutOfHealth : Decision
{
    public override bool Decide(StateMachine state)
    {
        var health = state.GetComponent<HealthPoints>();

        if (health.healthPoints > 0)
        {
            return false;
        }
        return true;
    }
}
