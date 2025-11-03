using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Wander", menuName ="FSM/States/Wander")]
public class Wander : State
{
    [SerializeField] float wanderRadius;
    [SerializeField] string wanderPointKey;

    public override void Enter(FSMController controller)
    {
        Vector3 movePoint = FindPoint(controller.transform.position);
        controller.Board.SetValue<Vector3>(wanderPointKey, movePoint);
        controller.Agent.SetDestination(movePoint);
    }

    public override void Exit(FSMController controller)
    {
        
    }

    public override void TickUpdate(FSMController controller)
    {
    }

    Vector3 FindPoint(Vector3 startPos)
    {
        Vector3 randomPoint = startPos + (Random.insideUnitSphere * wanderRadius);

        NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas);
        return hit.position;
    }
}
