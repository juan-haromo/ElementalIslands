using Fusion;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : NetworkBehaviour
{
    
    [SerializeField] Weapon weapon;
    [SerializeField] Movement movement;
    [SerializeField] Inventory inventory;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if (!GetInput<CustomInput>(out CustomInput networkInput)) { return; }

        movement.MoveCamera(networkInput.cameraMove, Runner.DeltaTime);
        movement.MovePlayer(networkInput.playerMove, Runner.DeltaTime);
        movement.HandleGravity(Runner.DeltaTime);
    }
}