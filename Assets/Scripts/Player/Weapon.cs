using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform hitStart;
    public float hitRadius;

    public void Attack(GameObject attacker)
    {
        Collider[] collided = Physics.OverlapSphere(hitStart.position, hitRadius);

        foreach(Collider col in collided)
        {
            if(col.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.Damage(attacker);
            }
        }
    }
}