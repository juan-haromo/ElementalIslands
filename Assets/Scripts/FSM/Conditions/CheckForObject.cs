using System.Collections.Generic;
using Fusion;
using UnityEngine;

[CreateAssetMenu(fileName = "CheckObject", menuName = "FSM/Conditions/CheckObject")]
public class CheckForObject : Condition
{
    public LayerMask objectMask;
    public float viewAngle;
    public float viewDistance;
    public string objectName;
    public override bool Check(FSMController controller)
    {
        Debug.DrawLine(controller.transform.position, controller.transform.position + (controller.transform.forward * viewDistance));
        List<Transform> objects = FindObject(controller.gameObject.transform, controller.Runner);
        if (objects.Count > 0)
        {
            controller.Board.SetValue<Transform>(objectName, objects[0]);
            return true;
        }
        return false;
    }

    public List<Transform> FindObject(Transform origin, NetworkRunner runner)
    {
        List<Transform> detectedObjects = new List<Transform>();
        //Detect all objects in range
        Collider[] objectsInRadius = new Collider[10];
        runner.GetPhysicsScene().OverlapSphere(origin.position, viewDistance, objectsInRadius, objectMask,QueryTriggerInteraction.Collide);
        foreach (Collider col in objectsInRadius)
        {
            if (col == null) { break; }
            //Check if object is in field of view
            Vector3 dir = (col.gameObject.transform.position - origin.position).normalized;
            float angleToObject = Vector3.Angle(dir, origin.forward);
            if (angleToObject > viewAngle / 2) { continue; }
            //Check if object is in line of sight
            RaycastHit hit;
            if (!runner.GetPhysicsScene().Raycast(origin.position, dir, out hit, viewDistance)) { continue; }
            if (hit.collider != col) { continue; }
            detectedObjects.Add(col.gameObject.transform);
        }
        return detectedObjects;
    }
}
