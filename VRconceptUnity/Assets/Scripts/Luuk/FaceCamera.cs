using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCamera; // assign VR camera in Inspector
    [SerializeField] private float rotationSpeed = 2f;  // how fast it rotates to follow player
    [SerializeField] private float spinSpeed = 50f;     // degrees per second self-spin
    [SerializeField] private bool flip180 = true;       // optional 180-degree flip

    void Update()
    {
        if (playerCamera == null) return;

        // Keep object in place
        Vector3 position = transform.position;

        // Calculate the horizontal direction to the player
        Vector3 direction = playerCamera.position - position;
        direction.y = 0; // keep upright

        if (direction.sqrMagnitude < 0.001f) return; // avoid zero-length vectors

        // Target rotation around Y axis
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        if (flip180)
            targetRotation *= Quaternion.Euler(0, 180f, 0);

        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Apply subtle self-spin on local Y-axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.Self);
    }
}

