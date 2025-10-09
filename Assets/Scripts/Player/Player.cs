using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    PlayerInput input;
    
    [SerializeField] Weapon weapon;


    [SerializeField] Movement movement;
    [SerializeField] Inventory inventory;
    void Awake()
    {
        input = new PlayerInput();

        input.Overworld.Enable();

        input.Overworld.Attack.performed += (CallbackContext contex) => weapon.Attack(gameObject);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        movement.MoveCamera(input.Overworld.Camera.ReadValue<Vector2>());
        movement.MovePlayer(input.Overworld.Move.ReadValue<Vector2>());
        movement.HandleGravity();
    }

}