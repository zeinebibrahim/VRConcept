using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    // [SerializeField] GameObject projectile;
    // [SerializeField] float firespeed;
    // [SerializeField] Transform spawnPoint;
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

    private void FireBullet(ActivateEventArgs args)
    {
        
        Debug.Log("Fire Bullet");
        
        // GameObject spawnBullet = Instantiate(projectile);
        // spawnBullet.transform.position = spawnPoint.position;
        // spawnBullet.GetComponent<Rigidbody>().linearVelocity = spawnPoint.forward * firespeed;
    }
}
