using UnityEngine;

public abstract class GunWeapon : Weapon
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float countProjectiles;
    [SerializeField] protected float fireRate;
}
