using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class MineralSpawn : NetworkBehaviour
{
    [SerializeField] GameObject mineral;

    [SerializeField] List<Transform> spawnPoint;
    

    public override void Spawned()
    {
        base.Spawned();
        Debug.Log(Runner.IsSharedModeMasterClient ? "Master" : "Peasant");
        Runner.Spawn(mineral, new Vector3(3, 3, 3), Quaternion.identity);
    }

    [Rpc(RpcSources.All,RpcTargets.All)]
    public void RPC_SpawnMinerals()
    {
        foreach(Transform point in spawnPoint)
        {
            Runner.Spawn(mineral, point.position, point.rotation);            
        }
    }
}