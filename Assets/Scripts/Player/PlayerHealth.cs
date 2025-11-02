using Fusion;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour, IDamageable
{
    [Networked,OnChangedRender(nameof(OnHealthChange))]
    float CurrentHealth { get; set; }
    [SerializeField] float maxHealth;

    public override void Spawned()
    {
        base.Spawned();
        CurrentHealth = maxHealth;
    }
    public void Damage(float damage)
    {
        RPC_Damage(damage);
    }

    [Rpc(RpcSources.All,RpcTargets.All)]
    void RPC_Damage(float damage)
    {
        CurrentHealth -= Mathf.Abs(damage);
    }

    void OnHealthChange()
    {
        Debug.Log("Current Health: " + CurrentHealth);
    }
}
