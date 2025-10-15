using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
     [SerializeField] ObjectPooler bulletPool;
     [SerializeField] Transform spawnPoint;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootPaint()
    {
        GameObject bullet = bulletPool.GetPooledObject();
        bullet.SetActive(true);
    }
    private void FireBullet(ActivateEventArgs args)
    {
        GameObject bullet = bulletPool.GetPooledObject();

        Debug.Log("Fire Bullet");
        
         bullet.SetActive(true);
         bullet.transform.position = spawnPoint.position;
         bullet.GetComponent<Rigidbody>().linearVelocity = spawnPoint.forward * speed;
    }
}