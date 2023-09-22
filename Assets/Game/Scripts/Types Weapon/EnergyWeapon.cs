using UnityEngine;

public abstract class EnergyWeapon : FirearmWeapon
{
    [Header("Energy Dependencies")]
    [SerializeField] protected LineRenderer rayRenderer;
    [SerializeField] protected LayerMask hitMask;
    [SerializeField] protected float energyRange = 1000f;
    [SerializeField] protected float energyCapacity = 100f;
    [SerializeField] protected float energyRequirementPerSecond = 5f;
}
