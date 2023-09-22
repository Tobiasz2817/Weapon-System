using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsPlaceHolder")]
public class WeaponsData : ScriptableObject
{
    [SerializeField] private List<Weapon> availableWeapons = new List<Weapon>();
    
    public Weapon GetWeapon(int index) {
        if (IsOutOfRange(index))
            return null;
        
        return availableWeapons[index];
    }

    public int WeaponsCount() => availableWeapons.Count;
    
    public bool IsOutOfRange(int index) {
        if (index >= availableWeapons.Count)
            return true;
        if (index < 0)
            return true;
        
        return false;
    }
}
