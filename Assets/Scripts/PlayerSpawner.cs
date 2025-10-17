using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject playerPrefab;
    [Networked]
    public static int PlayerCount{ get; private set; }
    [SerializeField] List<Transform> startPoints;
    [SerializeField] Transform levelCamera;

    public void PlayerJoined(PlayerRef player)
    {
        PlayerCount++;
        if(Runner.LocalPlayer == player)
        {
            Vector3 spawnPos = startPoints[UnityEngine.Random.Range(0, startPoints.Count)].position;
            NetworkObject newPlayer = Runner.Spawn(playerPrefab, spawnPos, playerPrefab.transform.rotation,player);
            levelCamera.gameObject.SetActive(false);
            newPlayer.GetComponentInChildren<Camera>(true).gameObject.SetActive(true);
            newPlayer.GetComponent<MeshRenderer>().material.color =  GetColor();
            
        }
    }

    private Color GetColor()
    {
        Color color;
        switch (PlayerCount % 4)
        {
            case 0:
                color = Color.yellow;
                break;
            case 1:
                color = Color.green;
                break;
            case 2:
                color = Color.red;
                break;
            case 3:
                color = Color.purple;
                break;
            default:
                color = Color.white;
                Debug.Log("Color error");
                break;
        }
        return color;
    }
}
