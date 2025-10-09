using UnityEngine;

public class Movement : MonoBehaviour
{

    #region UnityCalls
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position + groundCheckOffset, groundDetectionRadius);
    }
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    #endregion

    #region Camera
    [Header("Camera")]
    [SerializeField] Transform playerCamera;
    [SerializeField] float senseX;
    [SerializeField] float senseY;
    float yRotation;
    float xRotation;
    public void MoveCamera(Vector2 mouseInput)
    {
        yRotation += mouseInput.x * Time.deltaTime * senseX;
        xRotation -= mouseInput.y * Time.deltaTime * senseY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);
        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    #endregion

    #region Player Movement
    [Header("PlayerMovement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Transform orientation;
    CharacterController controller;
    Vector2 movementInput;
    Vector3 moveDirection;
    public void MovePlayer(Vector2 movementInput)
    {
        moveDirection = (orientation.forward * movementInput.y) + (orientation.right * movementInput.x);
        controller.Move(Time.deltaTime * moveSpeed * moveDirection.normalized);
    }
    #endregion

    #region Gravity
    [Header("Gravity")]
    [SerializeField] LayerMask groundMask;

    [SerializeField] float groundDetectionRadius = 1;
    [SerializeField] Vector3 groundCheckOffset;
    public void HandleGravity()
    {
        Collider[] groundCheck = Physics.OverlapSphere(transform.position + groundCheckOffset, groundDetectionRadius, groundMask);
        if (groundCheck.Length == 0)
        {
            controller.Move(Time.deltaTime * 9.81f * Vector3.down);
        }
    }
    #endregion
}
