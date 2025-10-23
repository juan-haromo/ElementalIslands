using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;

public class MineralSpawn : NetworkBehaviour
{
    [SerializeField] List<Collectable> minerals;

    [SerializeField] List<Transform> spawnPoints;

    void Awake()
    {
        StartCoroutine(WaitForServerSetUp());
    }

    IEnumerator WaitForServerSetUp()
    {
        while (Runner == null)
        {
            Debug.Log("Waiting for server");
            yield return null;
        }
        Debug.Log("Server running");
        if (Runner.IsServer)
        {
            Debug.Log("Mineral spawned");
            SpawnMinerals();
        }
        else
        {
            Debug.Log("No minerals?");
        }
    }

    public void SpawnMinerals()
    {
        foreach (Transform point in spawnPoints)
        {
            int mineralIndex = Random.Range(0, spawnPoints.Count);
            Runner.Spawn(spawnPoints[mineralIndex].gameObject, point.position, point.rotation);
        }
    }
}