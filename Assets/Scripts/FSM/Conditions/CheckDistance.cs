using UnityEngine;

[CreateAssetMenu(fileName = "CheckDistance", menuName = "FSM/Conditions/CheckDistance")]
public class CheckDistance : Condition
{
    [SerializeField] float minDistance;
    [SerializeField] string pointName;

    public override bool Check(FSMController controller)
    {
        Vector3 point = controller.Board.GetValue<Vector3>(pointName);

        if(point != null)
        {
            return Vector3.Distance(controller.transform.position, point) < minDistance;
        }
        return false;
    }
}