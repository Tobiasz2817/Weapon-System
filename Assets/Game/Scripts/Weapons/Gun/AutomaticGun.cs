using System.Collections;
using UnityEngine;

public class AutomaticGun : ProjectileWeapon
{
    private Coroutine automaticGunCoroutine;

    protected override void ProcessWeaponAction() {
        base.ProcessWeaponAction();
        
        if (CanShoot()) BaseShoot();
        automaticGunCoroutine = StartCoroutine(ProcessAutomaticShoot());
    }

    protected override void ReleaseWeaponAction() {
        base.ReleaseWeaponAction();
        
        if(automaticGunCoroutine != null)
            StopCoroutine(automaticGunCoroutine);
    }
    
    private IEnumerator ProcessAutomaticShoot() {
        while (true) {
            if (CanShoot()) 
                BaseShoot();
            yield return null;
        }
    }
}
