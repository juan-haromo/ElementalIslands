using Fusion;
using UnityEngine;

public class Collectable : NetworkBehaviour, IDamageable
{
    [SerializeField] int itemID;
    [Networked,OnChangedRender(nameof(HealthChange))]
    public float Health { get; set; } = 15;

    [Rpc(RpcSources.All,RpcTargets.All)]
    public void RPC_Damage(float damage)
    {
        Debug.Log("Damaged RPC");
        Health -= damage;
    }

    public void Damage(float damager)
    {
        Debug.Log("Damaged NOT RPC");
        RPC_Damage(damager);
    }

    void HealthChange()
    {
        Debug.Log("HealthChanged " + Health);
       if(Health < 0)
        {
            gameObject.SetActive(false);
        } 
    }
}