using UnityEngine;
using UnityEngine.InputSystem;

public class ExecuteWeaponAction : MonoBehaviour
{
    [SerializeField] private InputActionReference bind_1;
    [SerializeField] private InputActionReference bind_2;
    
    private void OnEnable() {
        bind_1.action.performed += PerformFirstBind;
        bind_1.action.canceled += PerformSecondBind;
        bind_2.action.performed += PerformFirstBind;
        bind_2.action.canceled += PerformSecondBind;
    }

    private void OnDisable() {
        bind_1.action.performed -= PerformFirstBind;
        bind_1.action.canceled -= PerformSecondBind;
        bind_2.action.performed -= PerformFirstBind;
        bind_2.action.canceled -= PerformSecondBind;
    }

    private void PerformFirstBind(InputAction.CallbackContext obj) {
        
    }

    private void PerformSecondBind(InputAction.CallbackContext obj) {
        
    }
}
