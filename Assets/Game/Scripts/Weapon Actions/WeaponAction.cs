using UnityEngine;

/// <summary>
/// I wasn't sure what type execution of weapons to choose,
/// this class or the executing basing on the input plugged to weapon.
/// Finally i choose the second solution
/// </summary>
[DisallowMultipleComponent]
public class WeaponAction : MonoBehaviour
{
    [SerializeField] public BaseInput baseInput;
    [SerializeField] private WeaponHandler weaponHandler;
    
    private Weapon currentWeapon;
    
    protected virtual void OnEnable() {
        baseInput.OnPress += ProcessWeaponAction;
        baseInput.OnRealesed += ReleaseWeaponAction;
    }
    
    protected virtual void OnDisable() {
        baseInput.OnPress -= ProcessWeaponAction;
        baseInput.OnRealesed -= ReleaseWeaponAction;
    }
    
    private void ProcessWeaponAction() {
        if (!weaponHandler.IsHoldingWeapon()) return;
        var weapon = weaponHandler.GetCurrentWeapon();
        //weapon.ProcessWeaponAction();
    }
    
    private void ReleaseWeaponAction() {
        if (!weaponHandler.IsHoldingWeapon()) return;
        var weapon = weaponHandler.GetCurrentWeapon();
        //weapon.ReleaseWeaponAction();
    }
}

