using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Chase")]
public class ChaseAction : FSMAction
{
    public override void Execute(StateMachine stateMachine)
    {
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        var enemySightSensor = stateMachine.GetComponent<SightSensor>();

        navMeshAgent.SetDestination(enemySightSensor.Player.position);
    }
}
