using UnityEngine;

[CreateAssetMenu(fileName = "Delay", menuName ="FSM/States/Delay")]
public class Delay : State
{

    [SerializeField] string delayName;
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;
    public override void Enter(FSMController controller)
    {
        controller.Board.SetValue(delayName, Time.time + Random.Range(minDelay, maxDelay));
        controller.Agent.SetDestination(controller.transform.position);
    }

    public override void Exit(FSMController controller)
    {

    }
    
    public override void TickUpdate(FSMController controller)
    {
        
    }
}