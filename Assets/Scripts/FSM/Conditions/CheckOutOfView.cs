

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OutOfView", menuName = "FSM/Conditions/OutOfView")]
public class CheckOutOfView : Condition
{
    public LayerMask objectMask;
    public float viewAngle;
    public float viewDistance;
    public string objectName;
    public override bool Check(FSMController controller)
    {
        Transform objectToFind = controller.Board.GetValue<Transform>(objectName);
        //No object to check, so always out of view
        if (objectToFind == default) { return true; }
        
        return !FindObject(controller.transform).Contains(objectToFind);
    }

    public List<Transform> FindObject(Transform origin)
    {
        List<Transform> detectedObjects = new List<Transform>();
        //Detect all objects in range
        Collider[] objectsInRadius = Physics.OverlapSphere(origin.position, viewDistance, objectMask);

        foreach (Collider col in objectsInRadius)
        {
            //Check if object is in field of vie
            Vector3 dir = (col.gameObject.transform.position - origin.position).normalized;
            float angleToObject = Vector3.Angle(dir, origin.forward);
            if (angleToObject > viewAngle / 2) { continue; }
            //Check if object is in line of sight
            RaycastHit hit;
            if (!Physics.Raycast(origin.position, dir, out hit, viewDistance)) { continue; }
            if (hit.collider != col) { continue; }
            detectedObjects.Add(col.gameObject.transform);
        }
        return detectedObjects;
    }
}

