using System.Collections;
using UnityEngine;

public class LaserGun : EnergyWeapons
{
    private Coroutine laserCoroutine;
    private CameraRay ray;
    
    private void Awake() {
        ray = Camera.main.GetComponent<CameraRay>();
    }

    protected override void ProcessWeaponAction() {
        laserCoroutine = StartCoroutine(ProcessLaserShoot());
    }

    protected override void ReleaseWeaponAction() {
        if(laserCoroutine != null)
            StopCoroutine(laserCoroutine);
        
        ResetLineRenderer();
    }

    private IEnumerator ProcessLaserShoot() {
        while (true) {
            rayRenderer.SetPosition(0, firePoint.position);

            var hit = ray.GetRay(hitMask,energyRange);
            rayRenderer.SetPosition(1, hit.point);
            
            yield return null;
        }
    }

    private void ResetLineRenderer() {
        rayRenderer.SetPosition(0,Vector3.zero);
        rayRenderer.SetPosition(1,Vector3.zero);
    }
}
