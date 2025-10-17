using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(1)]
public class InputProvider : SimulationBehaviour, INetworkRunnerCallbacks
{
    private PlayerInput inputActions;
    void Awake()
    {
        
    }

    public IEnumerator WaitForRunner()
    {
        Debug.Log("waiting");
        while (Runner == null)
        {
            yield return null;
        }
        Initialize();
    }

    void OnEnable()
    {
        StartCoroutine(WaitForRunner());;
    }

    void OnDisable()
    {
        if(Runner != null){ Runner.RemoveCallbacks(this); }
    }


    private void Initialize()
    {
        Debug.Log("Initialize");
        inputActions = new PlayerInput();
        inputActions.Overworld.Enable();
        Runner.AddCallbacks(this);
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        InputSystem.Update();
        CustomInput customInput = new CustomInput();
        var playerInput = inputActions.Overworld;

        customInput.cameraMove = playerInput.Camera.ReadValue<Vector2>();
        customInput.playerMove = playerInput.Move.ReadValue<Vector2>();

        input.Set<CustomInput>(customInput);
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        //throw new NotImplementedException();
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        // throw new NotImplementedException();
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        // throw new NotImplementedException();
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        // throw new NotImplementedException();
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        // throw new NotImplementedException();
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        // throw new NotImplementedException();
    }


    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        // throw new NotImplementedException();
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        // throw new NotImplementedException();
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        // throw new NotImplementedException();
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        // throw new NotImplementedException();
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        // throw new NotImplementedException();
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        // throw new NotImplementedException();
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        // throw new NotImplementedException();
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        // throw new NotImplementedException();
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        // throw new NotImplementedException();
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        // throw new NotImplementedException();
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        // throw new NotImplementedException();
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        // throw new NotImplementedException();
    }
}


public struct CustomInput : INetworkInput
{
    public Vector2 cameraMove;
    public Vector2 playerMove;
}
