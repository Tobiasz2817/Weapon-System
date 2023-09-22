using UnityEngine;

public abstract class ProjectileWeapon : FirearmWeapon
{
    [Header("Projectile Dependencies")]
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float countProjectiles;
    [SerializeField] protected float gunPower = 700;
    
    
    protected virtual void BaseShoot() {
        Vector3 direction = firePoint.forward;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        var bullet = Instantiate(bulletPrefab, firePoint.position, targetRotation);
        var bulletRb = bullet.GetComponent<Rigidbody>();
                
        bulletRb.AddForce(firePoint.forward * gunPower * Time.fixedDeltaTime,ForceMode.Impulse);
                
        ResetFireRate();
    }
}
