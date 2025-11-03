using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField] List<Transition> transitions;
    public abstract void Enter(FSMController controller);
    public abstract void Exit(FSMController controller);
    public abstract void TickUpdate(FSMController controller);

    public virtual void CheckTransitions(FSMController controller)
    {
        foreach(Transition t in transitions)
        {
            if (t.condition != null && t.condition.Check(controller))
            {
                controller.StateMachine.ChangeState(t.state);
                break;
            }
        }
    }
}