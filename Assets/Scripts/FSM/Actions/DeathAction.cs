using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Death")]
public class DeathAction : FSMAction
{
    public override void Execute(StateMachine stateMachine)
    {
        Debug.Log("dead");
        throw new System.NotImplementedException();
    }
}
