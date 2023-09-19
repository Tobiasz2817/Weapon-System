using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string weaponName;
    [SerializeField] protected float weaponDamage;
    [SerializeField] private BaseInput baseInput;
    protected virtual void OnEnable() {
        baseInput.OnPress += ProcessWeaponAction;
        baseInput.OnRealesed += ReleaseWeaponAction;
    }
    
    protected virtual void OnDisable() {
        baseInput.OnPress -= ProcessWeaponAction;
        baseInput.OnRealesed -= ReleaseWeaponAction;
    }

    protected abstract void ProcessWeaponAction();
    protected virtual void ReleaseWeaponAction() { }
}
