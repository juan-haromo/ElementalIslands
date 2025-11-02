using Fusion;
using UnityEngine;

public class BasicBullet : NetworkBehaviour
{
    Vector3 moveDirection;
    [SerializeField] float speed;
    public void Initialize(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        transform.Translate(speed * Runner.DeltaTime * moveDirection.normalized);
    }
}
