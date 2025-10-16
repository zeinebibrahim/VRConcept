using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Cache the main camera (player's headset camera)
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Make the UI face the camera
        Vector3 direction = transform.position - cameraTransform.position;
        direction.y = 0; // Optional: lock rotation so it only turns around the Y-axis
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
