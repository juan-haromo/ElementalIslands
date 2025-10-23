using UnityEngine;
using UnityEngine.SceneManagement;
using Fusion;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager Instance;

    public NetworkRunner runner;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Destroying duplicate of player info in " + name);
            Destroy(this);
        }
    }

    public async void StartGame()
    {
        NetworkSceneInfo sceneInfo = new NetworkSceneInfo();
        sceneInfo.AddSceneRef(SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex), LoadSceneMode.Additive);

        StartGameArgs args = new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = "islands",
            Scene = sceneInfo,
            SceneManager = runner.GetComponent<NetworkSceneManagerDefault>()
        };

        Debug.Log("Awaiting");
        await runner.StartGame(args);
        Debug.Log("Awaited boss");
    }
}
