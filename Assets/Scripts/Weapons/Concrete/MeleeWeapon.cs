
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Weapons/Melee")]
public class MeleeWeapon : Weapon
{
    [SerializeField] float attackRadius;
    [SerializeField] LayerMask hitMask;
    public override void Attack(Player player)
    {
        Vector3 hitStart = player.weapon.hitStart.position;
        Collider[] hits = new Collider[10];
        player.Runner.GetPhysicsScene().OverlapSphere(hitStart, attackRadius, hits,hitMask, QueryTriggerInteraction.Collide);
        Debug.DrawRay(hitStart, (attackRadius * 0.5f) * Vector3.forward,Color.magenta,0.5f);
        Debug.DrawRay(hitStart, (attackRadius * 0.5f) * Vector3.back,Color.magenta,0.5f);
        Debug.DrawRay(hitStart, (attackRadius * 0.5f) * Vector3.left,Color.magenta,0.5f);
        Debug.DrawRay(hitStart, (attackRadius * 0.5f) * Vector3.right,Color.magenta,0.5f);
        foreach (Collider c in hits)
        {
            if(c == null){break; }
            if (c.gameObject == player.gameObject) { Debug.Log("self"); continue; }
            if (c.gameObject == player.gameObject) { continue; }
            if (c.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                Debug.Log(c.gameObject.name);
                damageable.Damage(10);
            }
        }
    }
}