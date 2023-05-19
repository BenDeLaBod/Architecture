using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Is Enemy")]
public class IsEnemy : Decision
{
    public override bool Decide(StateMachine state)
    {
        var enemyCheck = state.GetComponent<IsEnemyChecker>();

        return enemyCheck.CheckForEnemy();
    }
}
