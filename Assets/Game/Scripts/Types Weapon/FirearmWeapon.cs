using UnityEngine;

public abstract class FirearmWeapon : Weapon
{
    // Some values depends on game aspect
    [Header("Firearm Dependencies")]
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float brokeDurability = 2f; // Per Shot
    [SerializeField] protected float maxDurability = 100f;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected float fireRate = 0.2f; // Delay Time In Second 
    [SerializeField] protected float accuracy;
    [SerializeField] protected float spread;
    [SerializeField] protected float recoil;

    protected float currentFireRateTime = 0;

    // Its only a Example, we can make other script which handling fire rate
    private void Start() {
        currentFireRateTime = fireRate;
    }

    protected virtual void Update() {
        HandleFireRate();
    }

    private void HandleFireRate() {
        if (!CanShoot())
            currentFireRateTime += Time.deltaTime;
    }

    protected bool CanShoot() {
        return !(currentFireRateTime < fireRate);
    }
    
    protected void ResetFireRate() {
        currentFireRateTime = 0;
    }
    
    // Examples
    protected void HandleRecoil() { }
    protected void TakeDurability() { }
}
