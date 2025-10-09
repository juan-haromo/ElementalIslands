using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput input;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform front;

    void Awake()
    {
        input = new PlayerInput();

        input.Overworld.Enable();
    }

    void Update()
    {
        
    }
}
