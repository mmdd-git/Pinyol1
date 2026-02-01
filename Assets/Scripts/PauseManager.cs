using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour, InputSystem_Actions.IUIActions
{
    private InputSystem_Actions inputActions;
    public static bool IsPaused = false;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.UI.SetCallbacks(this);
    }
    public void OnEnable() => inputActions.Enable();
    public void OnDisable() => inputActions.Disable();

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
    }
    public void Pause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
    }
}