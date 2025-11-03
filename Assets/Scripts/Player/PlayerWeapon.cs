using Fusion;
using UnityEngine;

public class PlayerWeapon : NetworkBehaviour
{
    public Transform hitStart;
    public float hitRadius;
    public Player owner;

    [Networked]
    public int CurrentWeapon{ get; private set; }

    public void Attack()
    {
        RPC_Attack();
    }

    [Rpc(RpcSources.All, RpcTargets.InputAuthority)]
    void RPC_Attack()
    {
        WeaponManager.Instance.Attack(CurrentWeapon, owner);
    }

    public void NextWeapon()
    {
        Debug.Log("next");
        CurrentWeapon = (CurrentWeapon + WeaponManager.Instance.totalWeapons - 1) % WeaponManager.Instance.totalWeapons;
    }
    
    public void PreviousWeapon()
    {
        Debug.Log("previous");
        CurrentWeapon = (CurrentWeapon + 1) % WeaponManager.Instance.totalWeapons;
    }
}