using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;

    public string username { get; private set; }

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

    public void SetUsername(string username)
    {
        this.username = username;
    }
}
