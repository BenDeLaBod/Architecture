using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
public class PatrolAction : FSMAction
{
    public override void Execute(StateMachine stateMachine)
    {
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();

        if (patrolPoints.HasReached(navMeshAgent))
            navMeshAgent.SetDestination(patrolPoints.GetNext().position);
    }
}