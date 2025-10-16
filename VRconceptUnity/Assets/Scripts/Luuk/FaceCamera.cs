using UnityEngine;

public class FaceCamera : MonoBehaviour
{
   private float rotationSpeed = 5f;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        Vector3 direction = transform.position - cameraTransform.position;
        direction.y = 0; // keep only horizontal rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
