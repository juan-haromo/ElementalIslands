using Fusion;
using UnityEngine;

public class Mineral : NetworkBehaviour, IDamageable
{
    [SerializeField] int itemID;

    [SerializeField]
    float maxHealth;

    [Networked, OnChangedRender(nameof(HealthChange))]
    public float Health { get; set; }
    [SerializeField] MineralSpawn spawn;


    public override void Spawned()
    {
        base.Spawned();
        Health = maxHealth;
    }


    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_Damage(float damage)
    {
        Health -= damage;
    }

    public void Damage(float damager)
    {
        RPC_Damage(damager);
    }

    void HealthChange()
    {
        if (Health < 0)
        {
            Health = maxHealth;
            RPC_CollectMineral();
        }
    }
    
    [Rpc(RpcSources.All,RpcTargets.All)]
    void RPC_CollectMineral()
    {
        spawn.SpawnMineral();
    }
}