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
    public ParticleSystem speedParticles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (PauseManager.IsPaused) return;

        if (!isFloating)
        {
            Move();
            Jump();
        }
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
        // Direcció
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Evitar inclinació
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Direcció final input
        Vector3 direction = forward * moveInput.y + right * moveInput.x;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime));
        }

        // Move
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

    public void MakeInvisible(float duration)
    {
        StartCoroutine(InvisibilityRoutine(duration));
    }

    private System.Collections.IEnumerator InvisibilityRoutine(float duration)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
            r.enabled = false;

        yield return new WaitForSeconds(duration);

        foreach (Renderer r in renderers)
            r.enabled = true;
    }

    private bool isFloating = false;

    public void StartFloating(float duration)
    {
        StartCoroutine(FloatRoutine(duration));
    }

    private System.Collections.IEnumerator FloatRoutine(float duration)
    {
        isFloating = true;
        rb.useGravity = false;

        float targetHeight = transform.position.y + 1f; // altura donde flotará
        float timer = 0f;

        while (timer < duration)
        {
            float currentY = transform.position.y;

            // Control vertical suave
            float difference = targetHeight - currentY;

            // Fuerza proporcional (como un muelle suave)
            float floatForce = difference * 8f;

            // Limitar fuerza para evitar explosiones
            floatForce = Mathf.Clamp(floatForce, -10f, 10f);

            rb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);

            // Pequeña oscilación estética
            rb.AddForce(Vector3.up * Mathf.Sin(Time.time * 6f) * 0.2f, ForceMode.Acceleration);

            timer += Time.deltaTime;
            yield return null;
        }

        rb.useGravity = true;
        isFloating = false;
    }

    private bool isSpeedBoosted = false;
    private float originalSpeed;

    public void StartSpeedBoost(float duration, float multiplier)
    {
        StartCoroutine(SpeedBoostRoutine(duration, multiplier));
    }

    private System.Collections.IEnumerator SpeedBoostRoutine(float duration, float multiplier)
    {
        if (!isSpeedBoosted)
        {
            isSpeedBoosted = true;
            originalSpeed = moveSpeed;
            moveSpeed *= multiplier;

            if (speedParticles != null)
                speedParticles.Play();
        }

        yield return new WaitForSeconds(duration);

        moveSpeed = originalSpeed;
        isSpeedBoosted = false;

        if (speedParticles != null)
            speedParticles.Stop();
    }
}