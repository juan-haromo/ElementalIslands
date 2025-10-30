using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class MineralSpawn : NetworkBehaviour
{
    [SerializeField] List<Collectable> minerals;

    [SerializeField] List<Transform> spawnPoints;

    public override void Spawned()
    {
        base.Spawned();
        if (Runner.IsSharedModeMasterClient)
        {
            RPC_SpawnMinerals();
        }
    }

    [Rpc(RpcSources.All,RpcTargets.All)]
    public void RPC_SpawnMinerals()
    {
        foreach (Transform point in spawnPoints)
        {
            int mineralIndex = Random.Range(0, minerals.Count);
            Runner.Spawn(minerals[mineralIndex].gameObject, point.position, point.rotation);
        }
    }
}