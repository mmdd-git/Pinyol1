using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused = false;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        IsPaused = !IsPaused;

        Time.timeScale = IsPaused ? 0f : 1f;
    }

    public void Pause()
    {
        PauseManager.IsPaused = !PauseManager.IsPaused;
        Time.timeScale = PauseManager.IsPaused ? 0f : 1f;
    }
}