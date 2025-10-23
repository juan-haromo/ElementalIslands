using UnityEngine;

public class MenuUI : MonoBehaviour
{
    private string username;

    public void JoinGame()
    {
        NetworkManager.Instance.StartGame();
    }
}
