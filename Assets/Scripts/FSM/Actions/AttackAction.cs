using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "FSM/Actions/Attack")]

public class AttackAction : FSMAction
{
    float time;
    public override void Execute(StateMachine stateMachine)     
    {
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        //navMeshAgent.isStopped = true;
        navMeshAgent.speed = 3.5f;
        navMeshAgent.SetDestination(new Vector3(
                        stateMachine.transform.position.x + Random.Range(-3, 3),
                        stateMachine.transform.position.y,
                        stateMachine.transform.position.z + Random.Range(-3, 3)));
        var attack = stateMachine.GetComponent<AiShooting>();
        attack.shoot();

       
    }
}
