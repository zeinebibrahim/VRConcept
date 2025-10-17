using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    [SerializeField] ObjectPooler bulletPool;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Reloading reloading;
    [SerializeField] float speed;

    void Start()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.AddListener(FireBullet);
    }

    private void FireBullet(ActivateEventArgs args)
    {
        // Only fire if NOT reloading
        if (!reloading.GetReloadStatus())
        {
            int ammo = reloading.GetCurrentAmmo();

            if (ammo <= 0)
            {
                return;
            }

            GameObject bullet = bulletPool.GetPooledObject();
            bullet.SetActive(true);
            bullet.transform.position = spawnPoint.position;
            bullet.GetComponent<Rigidbody>().linearVelocity = spawnPoint.forward * speed;

            // Reduce ammo
            ammo--;
            reloading.SetCurrentAmmo(ammo);
        }
        else
        {
            print("reloading");
        }
    }
}
