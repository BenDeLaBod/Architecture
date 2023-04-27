using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public sealed class State : BaseState
{
    public List<FSMAction> Action = new List<FSMAction>();
    public List<Transition> Transitions = new List<Transition>();
    // Start is called before the first frame update
    
    public override void Execute(StateMachine machine)
    {
        foreach (var action in Action)
            action.Execute(machine);

        foreach (var transition in Transitions)
            transition.Execute(machine);
    }

    // Update is called once per frame
}
