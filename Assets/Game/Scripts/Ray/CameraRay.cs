using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private InputActionReference inputRayReference;
    [SerializeField] private LayerMask rayMask;
    [SerializeField] private float basedMaxDistance = 1000;
    [SerializeField] private bool displayRay = false;
    
    private Vector2 mouseLastInput;

    public event Action<RaycastHit> OnDetected;
    
    private void OnEnable() {
        inputRayReference.action.performed += ReadMousePosition;
        inputRayReference.action.Enable();
    }

    private void OnDisable() {
        inputRayReference.action.performed -= ReadMousePosition;
        inputRayReference.action.Disable();
    }

    private void ReadMousePosition(InputAction.CallbackContext obj) {
        mouseLastInput = obj.ReadValue<Vector2>();
        var raycast = GetRay(mouseLastInput,rayMask,basedMaxDistance);
        if (raycast.point == default) return;
        OnDetected?.Invoke(raycast);
    }
    
    
    public RaycastHit GetRay() => GetRay(mouseLastInput, rayMask,basedMaxDistance);
    public RaycastHit GetRay(LayerMask layerMask) => GetRay(mouseLastInput,layerMask,basedMaxDistance);
    public RaycastHit GetRay(float maxDistance) => GetRay(mouseLastInput,rayMask,maxDistance);
    public RaycastHit GetRay(LayerMask layerMask, float maxDistance) =>  GetRay(mouseLastInput,layerMask,maxDistance);
    
    public RaycastHit GetRay(Vector3 pos,LayerMask layerMask, float maxDistance) {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        RaycastHit info;
        if (Physics.Raycast(ray, out info,maxDistance,layerMask)) {
            var distance = Vector3.Distance(ray.origin, info.point);
            info.point = ray.GetPoint(distance);
        }
        else {
            info.point = ray.GetPoint(maxDistance);
        }

        return info;
    }
    


    private void Update() {
        if (!displayRay) return;
        var ray = GetRay(mouseLastInput, rayMask, basedMaxDistance);
        Debug.DrawLine(UnityEngine.Camera.main.transform.position,ray.point,Color.black);
    }
}
