using UnityEngine;

public class TriggerCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out IDestroyable destroyable)) 
            destroyable.DestroySelf();
    }
}
