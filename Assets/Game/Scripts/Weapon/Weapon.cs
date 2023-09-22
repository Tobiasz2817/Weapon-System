using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Dependencies")]
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
    
    public string GetWeaponName() => weaponName;
    public float GetWeaponDamage() => weaponDamage;
    
    protected virtual void ProcessWeaponAction() { Debug.Log($"{weaponName} started executing and dealing {weaponDamage} damage"); }
    protected virtual void ReleaseWeaponAction() { Debug.Log($"{weaponName} finish executing"); }
}
