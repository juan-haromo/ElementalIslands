using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    
    [SerializeField] Weapon weapon;
    [SerializeField] Movement movement;
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
            Debug.Log("Attacking");

            Collider[] collided = new Collider[10]; 
            Runner.GetPhysicsScene().OverlapSphere(hitStart.position, hitRadius, collided, hitmask,QueryTriggerInteraction.Collide);
            Debug.Log(collided.Length);
            foreach (Collider col in collided)
            {
                if(col == null){ Debug.Log("No more colliders"); break; }
                if (col.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    Debug.Log("damage component");

                    damageable.Damage(10);
                }
            }
        }
    }
}