using Fusion;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeWeapon", menuName = "Weapons/Range")]
public class RangeWeapon : Weapon
{
    [SerializeField] GameObject bullet;

    public override void Attack(Player player)
    {
        player.Runner.Spawn(bullet, player.weapon.hitStart.position, Quaternion.identity).GetComponent<BasicBullet>().Initialize(player.movement.playerCamera.forward);
    }
}