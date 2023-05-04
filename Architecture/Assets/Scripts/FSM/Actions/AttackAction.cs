using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "FSM/Actions/Attack")]

public class AttackAction : FSMAction
{
    public override void Execute(StateMachine stateMachine)
    {
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;

        var attack = stateMachine.GetComponent<AiShooting>();
        attack.shoot();

       
    }
}
