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
            Debug.Log(player + " joined");
            int i = Random.Range(0, startPoints.Count);
            Debug.Log("Random number picked between 0 and " + startPoints.Count + " is " + i);
            Vector3 spawnPos = startPoints[i].position;
            Debug.Log(spawnPos);
            NetworkObject newPlayer = Runner.Spawn(playerPrefab, spawnPos, playerPrefab.transform.rotation, player);
            levelCamera.gameObject.SetActive(false);
            newPlayer.GetComponentInChildren<Camera>(true).gameObject.SetActive(true);
        }
    }
}
