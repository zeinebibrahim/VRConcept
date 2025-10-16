using UnityEngine;
public class CollisionMovementTest : MonoBehaviour
{
    [SerializeField] LayerMask muurLayer;
    public float speed = 5f; // Movement speed
    public float jumpForce = 5f; // Jump force
    [SerializeField] Rigidbody rb; // Reference to Rigidbody component
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Initialize Rigidbody
    }
    void Update()
    {
        // Get input for horizontal and vertical movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        // Calculate movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        // Apply movement
        rb.MovePosition(transform.position + move * speed * UnityEngine.Time.deltaTime);
        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    bool IsGrounded()
    {
        // Check if the player is on the ground
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == muurLayer)
        {
        }
        print("CollisionMuur");
    }
}