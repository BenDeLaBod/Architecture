using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
public class PatrolAction : FSMAction
{
    public override void Execute(StateMachine stateMachine)
    {
        stateMachine.animator.SetBool("ADSing", false);
        stateMachine.animator.SetBool("isMoving", true);
        stateMachine.animator.SetBool("isSprinting", false);

        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
        navMeshAgent.isStopped = false;

        if (patrolPoints.HasReached(navMeshAgent))
            navMeshAgent.SetDestination(patrolPoints.GetNext().position);
    }
}
