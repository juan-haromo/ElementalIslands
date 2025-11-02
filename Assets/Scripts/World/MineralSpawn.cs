using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class MineralSpawn : NetworkBehaviour
{
    [SerializeField] List<GameObject> Minerals;
    [Networked, OnChangedRender(nameof(OnActiveMineralChange))]
    int ActiveMineral { get; set; } = 0;

    public override void Spawned()
    {
        base.Spawned();
        if(!Runner.IsSharedModeMasterClient){ OnActiveMineralChange(); return; }
        SpawnMineral();
    }
    public void SpawnMineral()
    {
        if (!Runner.IsSharedModeMasterClient) { return; }
        ActiveMineral = Random.Range(0, Minerals.Count);
    }

    void OnActiveMineralChange()
    {
        foreach (GameObject g in Minerals)
        {
            g.SetActive(false);
        }
        Minerals[ActiveMineral].SetActive(true);
    }
}