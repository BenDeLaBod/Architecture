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
        //navMeshAgent.isStopped = true;
        navMeshAgent.speed = 3.5f;
        navMeshAgent.SetDestination(new Vector3(
                        stateMachine.transform.position.x + Random.Range(-3, 3),
                        stateMachine.transform.position.y,
                        stateMachine.transform.position.z + Random.Range(-3, 3)));
        var attack = stateMachine.GetComponentInChildren<Gun>();
        var player = GameObject.FindGameObjectWithTag("Player");

        stateMachine.transform.LookAt(player.transform);
        stateMachine.transform.eulerAngles = new Vector3(0, stateMachine.transform.eulerAngles.y, 0);
        attack.Shoot();
        if (attack.bulletsInMag == 0)
        {
            attack.Reload();
        }

       
    }
}
