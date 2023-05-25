using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Chase")]
public class ChaseAction : FSMAction
{
    public override void Execute(StateMachine stateMachine)
    {
        stateMachine.animator.SetBool("ADSing", false);
        stateMachine.animator.SetBool("isMoving", true);
        stateMachine.animator.SetBool("isSprinting", true);

        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        var enemySightSensor = stateMachine.GetComponent<SightSensor>();

        
        if (Vector3.Distance(stateMachine.transform.position, enemySightSensor.Player.position) > 7)
        {
            navMeshAgent.isStopped = false;
            Debug.Log("hehe");
            navMeshAgent.SetDestination(enemySightSensor.Player.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
            //navMeshAgent.speed = 20f;
            //navMeshAgent.SetDestination(new Vector3(
            //                stateMachine.transform.position.x + Random.Range(-3, 3),
            //                stateMachine.transform.position.y,
            //                stateMachine.transform.position.z + Random.Range(-3, 3)));
        }
            
        
    }
}
