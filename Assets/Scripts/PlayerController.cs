using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CubeMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool jumpPressed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump()
    {
        jumpPressed = true;
    }

    private void Move()
    {
        // Dirección de la cámara
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Evitar inclinación vertical
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Dirección final según input
        Vector3 direction = forward * moveInput.y + right * moveInput.x;

        // Si hay movimiento, rotar al jugador hacia esa dirección
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime));
        }

        // Mover al jugador
        Vector3 targetPos = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPos);
    }

    private void Jump()
    {
        if (jumpPressed && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        jumpPressed = false;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}