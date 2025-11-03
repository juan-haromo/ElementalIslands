using UnityEngine;

[CreateAssetMenu(fileName = "MoveToTransform",menuName ="FSM/States/MoveToTransform")]
public class MoveToTransform : State
{
    [SerializeField] string transformName;

    public override void Enter(FSMController controller)
    {
    }

    public override void Exit(FSMController controller)
    {
    }

    public override void TickUpdate(FSMController controller)
    {
        Transform destination = controller.Board.GetValue<Transform>(transformName);
        Debug.Log(destination.gameObject);
        if( destination == null || destination == default) { return; }
        controller.Agent.SetDestination(destination.position);
    }
}