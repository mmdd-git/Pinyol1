using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float rotationSpeed = 90f;
    public Transform player;

    private Vector2 lookInput;
    private float yaw; 
    private float pitch; 

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }



    void LateUpdate()
    {
        if (PauseManager.IsPaused) return;

        if (target == null)
            return;

        yaw += lookInput.x * rotationSpeed * Time.deltaTime;
        pitch -= lookInput.y * rotationSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        transform.position = target.position + offset;
        transform.LookAt(target);

        Vector3 forward = transform.forward;
        forward.y = 0;
        player.forward = forward;
    }

}