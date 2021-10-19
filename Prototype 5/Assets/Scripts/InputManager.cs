using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Input Manager", menuName = "Input Manager", order = 1)]
public class InputManager : ScriptableObject
{
    #region Events

    public delegate void StartTouch();
    public event StartTouch OnStartEvent;

    public delegate void EndTouch();
    public event EndTouch OnEndEvent;

    #endregion

    #region properties
    private Touch _touch;
    private Camera _mainCamera;
    #endregion

    #region MonoBehaviour Callbacks

    private void OnEnable()
    {
        _touch = new Touch();
        _mainCamera = Camera.main;
        
        _touch.Enable();

        _touch.Swipe.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        _touch.Swipe.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void OnDisable()
    {
        _touch.Disable();
    }

    #endregion
    private void StartTouchPrimary(InputAction.CallbackContext ctx)
    {
        OnStartEvent?.Invoke();
    }

    private void EndTouchPrimary(InputAction.CallbackContext ctx)
    {
        OnEndEvent?.Invoke();
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(_mainCamera, _touch.Swipe.PrimaryPosition.ReadValue<Vector2>());
    }
}
