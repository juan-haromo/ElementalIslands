using Fusion;
using UnityEngine;

public class Weapon : NetworkBehaviour
{
    public Transform hitStart;
    public float hitRadius;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitStart.position, hitRadius);
    }

    public void Attack(float damage)
    {
   
    }
}