using Fusion;
using UnityEngine;
using UnityEngine.AI;
public class FSMController : NetworkBehaviour
{
    public StateMachine StateMachine { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    public BlackBoard Board{ get; private set; }

    [SerializeField] State initialState;

    public override void Spawned()
    {
        base.Spawned();
        if (!Runner.IsSharedModeMasterClient) { return; }
        StateMachine = new StateMachine(this);
        Board = new BlackBoard();
        StateMachine.Initialize(initialState);
    }

    void Update()
    {
        if (!Runner.IsSharedModeMasterClient) { return; }
        StateMachine.CurrentState.TickUpdate(this);
    }
}