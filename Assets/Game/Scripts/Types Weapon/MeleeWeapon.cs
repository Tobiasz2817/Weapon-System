using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
    [SerializeField] protected float durability;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float range;
}
