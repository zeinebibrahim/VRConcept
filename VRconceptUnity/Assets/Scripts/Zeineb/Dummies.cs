using UnityEngine;

public class Dummies : MonoBehaviour
{
    [SerializeField] float grote = 2f;
    [SerializeField] float speed = 2f;

    void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * grote; //Makes it move accordingly and smoothly on the x as
        transform.position = new Vector3(x, transform.position.y, transform.position.z); //Object gets new transform position
    }
}
