using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    
    public PlayerWeapon weapon;
    public Movement movement;
    [SerializeField] Inventory inventory;
    [SerializeField] Transform hitStart;
    [SerializeField] float hitRadius;
    [SerializeField] LayerMask hitmask;
    bool attack = false;
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

        if (networkInput.attacked)
        {
            attack = false;
            weapon.Attack();
        }
    }
}