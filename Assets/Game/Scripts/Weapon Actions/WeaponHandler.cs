using UnityEngine;
using System;

[DisallowMultipleComponent]
public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private BaseInput swampWeaponInput;
    [SerializeField] private BaseInput pickUpWeaponInput;
    [SerializeField] private WeaponsData weaponsData;
    [SerializeField] private Transform weaponPlace;
    
    private Weapon currentWeapon;
    private IntegerIndexer integerIndexer;
    
    public Action<Weapon> OnDetachWeapon;
    public Action<Weapon> OnAttachWeapon;

    
    private void Awake() {
        integerIndexer = new IntegerIndexer(weaponsData.WeaponsCount());
    }

    private void Start() {
        var startWeapon = weaponsData.GetWeapon(0);
        AttachWeapon(startWeapon);
    }

    private void OnEnable() {
        swampWeaponInput.OnPress += ProcessDetachWeapon;
        swampWeaponInput.OnPress += ProcessAttachWeapon;
    }

    private void OnDisable() {
        swampWeaponInput.OnPress -= ProcessDetachWeapon;
        swampWeaponInput.OnPress -= ProcessAttachWeapon;
    }

    private void ProcessDetachWeapon() {
        var weapon = currentWeapon;
        DetachWeapon(weapon);
    }

    private void ProcessAttachWeapon() {
        var index = integerIndexer.GetNextIndex();
        var weapon = weaponsData.GetWeapon(index);
        if (currentWeapon == weapon) return;
        AttachWeapon(weapon);
    }

    private void AttachWeapon(Weapon weaponPrefab) {
        if (weaponPrefab == null) return;
        var newWeapon = Instantiate(weaponPrefab, weaponPlace);
        currentWeapon = newWeapon;
        OnAttachWeapon?.Invoke(newWeapon);
    }

    private void DetachWeapon(Weapon weaponReference) {
        if (weaponReference == null) return;
        Destroy(weaponReference.gameObject);
        OnDetachWeapon?.Invoke(weaponReference);
        currentWeapon = null;
    }


    public Weapon GetCurrentWeapon() => null;
    public bool IsHoldingWeapon() => true;
}
