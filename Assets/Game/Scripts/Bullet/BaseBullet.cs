using UnityEngine;

public class BaseBullet : MonoBehaviour, IDestroyable
{
    public void DestroySelf() {
        Destroy(gameObject);
    }
}
