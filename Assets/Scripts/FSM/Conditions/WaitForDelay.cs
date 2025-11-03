
using UnityEngine;
[CreateAssetMenu(fileName = "WaitForDelay", menuName ="FSM/Conditions/WaitForDelay")]
public class WaitForDelay : Condition
{
    [SerializeField] string delayName;

    public override bool Check(FSMController controller)
    {
        return controller.Board.GetValue<float>(delayName) < Time.time;
    }
}