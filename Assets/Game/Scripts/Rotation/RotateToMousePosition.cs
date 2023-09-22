using UnityEngine;

public class RotateToMousePosition : MonoBehaviour
{
    private CameraRay cameraRay;
    private void Awake() {
        cameraRay = Camera.main.GetComponent<CameraRay>();
    }

    private void OnEnable() {
        cameraRay.OnDetected += RotateTo;
    }

    private void OnDisable() {
        cameraRay.OnDetected -= RotateTo;
    }
    
    private void RotateTo(RaycastHit hit) {
        transform.LookAt(hit.point);
    }
}
