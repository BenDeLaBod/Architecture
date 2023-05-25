using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Friendly")]

public class FriendlyAction : FSMAction
{
    public override void Execute(StateMachine stateMachine)
    {
        stateMachine.animator.SetBool("ADSing", false);
        stateMachine.animator.SetBool("isMoving", false);
        stateMachine.animator.SetBool("isSprinting", false);

        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        Debug.LogWarning("Friendly");
        navMeshAgent.isStopped = true;
    }
}
