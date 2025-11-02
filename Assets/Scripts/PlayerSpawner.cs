using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] List<Transform> startPoints;
    [SerializeField] Transform levelCamera;

    public void PlayerJoined(PlayerRef player)
    {
        if (Runner.LocalPlayer == player)
        {
            NetworkObject newPlayer = Runner.Spawn(playerPrefab, new Vector3(0,2,0), playerPrefab.transform.rotation, player);
            levelCamera.gameObject.SetActive(false);
            newPlayer.GetComponentInChildren<Camera>(true).gameObject.SetActive(true);
        }
    }
}
