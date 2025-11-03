using System;
using UnityEngine.AI;

[Serializable]
public class StateMachine
{

    public FSMController controller { get; private set; }
    public StateMachine(FSMController controller)
    {
        this.controller = controller;
    }

    public State CurrentState { get; private set; }

    public void Initialize(State initialState)
    {
        CurrentState = initialState;
        initialState.Enter(controller);
    }

    public void ChangeState(State newState)
    {
        CurrentState.Exit(controller);
        CurrentState = newState;
        CurrentState.Enter(controller);
    }
}