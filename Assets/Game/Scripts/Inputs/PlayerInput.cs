using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : BaseInput
{
    [SerializeField] private InputActionReference inputBind;

    protected virtual void OnEnable() {
        inputBind.action.performed += InvokeAttackBind;
        inputBind.action.canceled += InvokeAttackBind;
        inputBind.action.Enable();
    }

    protected virtual void OnDisable() {
        inputBind.action.performed -= InvokeAttackBind;
        inputBind.action.canceled -= InvokeAttackBind;
        inputBind.action.Disable();
    }
    
    private void InvokeAttackBind(InputAction.CallbackContext callbackContext) {
        if (callbackContext.performed) 
            OnPress?.Invoke();
        else if (callbackContext.canceled)
            OnRealesed?.Invoke();
    }
}
