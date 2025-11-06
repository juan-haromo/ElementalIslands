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
        Agent = GetComponent<NavMeshAgent>();
        Agent.enabled = false;
        if (!Runner.IsSharedModeMasterClient) { return; }
        Agent.enabled = true;
        StateMachine = new StateMachine(this);
        Board = new BlackBoard();
        StateMachine.Initialize(initialState);
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

    }

    void Update()
    {
        if (Runner == null) { return; }
        if (!Runner.IsSharedModeMasterClient) { return; }
        StateMachine.CurrentState.TickUpdate(this);
        StateMachine.CurrentState.CheckTransitions(this);
    }
}