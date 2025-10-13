using UnityEngine;

public class LaunchTest : MonoBehaviour
{
    public GameObject bulletPrefab;    // Prefab van je kogel
    public Transform spawnPoint;       // Waar de kogel verschijnt
    public float shootForce = 20f;     // Kracht van de kogel
    public float spreadAngle = 5f;     // Lichte random afwijking
    public float cooldown = 0.5f;      // Tijd tussen schoten in seconden
    public float shootingDuration = 5f; // Hoe lang het automatisch schieten duurt

    private float lastShotTime;
    private float startTime;

    void Start()
    {
        startTime = Time.time; // starttijd vastleggen
    }

    void Update()
    {
        // Check of de shootingDuration voorbij is
        if (Time.time - startTime > shootingDuration)
            return; // stop met schieten

        if (Time.time >= lastShotTime + cooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && spawnPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Lichte random afwijking in richting
                Vector3 randomDirection = spawnPoint.forward;
                float angleX = Random.Range(-spreadAngle, spreadAngle);
                float angleY = Random.Range(-spreadAngle, spreadAngle);
                randomDirection = Quaternion.Euler(angleX, angleY, 0) * randomDirection;

                rb.AddForce(randomDirection * shootForce, ForceMode.VelocityChange);
            }
        }
    }
}
