using UnityEngine;

public class EnergyWeapons : Weapon
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected LineRenderer rayRenderer;
    [SerializeField] protected LayerMask hitMask;
    [SerializeField] protected float energyRange = 1000f;
    [SerializeField] protected float reloadTime = 4f;
    [SerializeField] protected float energyCapacity = 100f;
    [SerializeField] protected float energyRequirementPerSecond = 5f;

    protected override void ProcessWeaponAction() { }
    protected override void ReleaseWeaponAction() { }
}
