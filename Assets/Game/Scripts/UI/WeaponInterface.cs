using UnityEngine;
using TMPro;

public class WeaponInterface : MonoBehaviour
{
    [SerializeField] private TMP_Text weaponNameText;
    [SerializeField] private TMP_Text weaponDamageText;
    [SerializeField] private WeaponHandler weaponHandler;

    private void OnEnable() {
        weaponHandler.OnAttachWeapon += RefreshInterface;
    }
    
    private void OnDisable() {
        weaponHandler.OnAttachWeapon -= RefreshInterface;
    }
    
    private void RefreshInterface(Weapon weapon) {
        weaponNameText.text = weapon.GetWeaponName();
        weaponDamageText.text = weapon.GetWeaponDamage().ToString() + " Damage";
    }
}
