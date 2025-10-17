using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;
    private float lifeTimer;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        lifeTimer = lifeTime;
    }
    private void Update()
    {

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
    // destroys the bullet if a collision occurs with any other object.
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
