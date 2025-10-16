using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField] LayerMask muurLayer;

    [SerializeField] float groter = 2f;
    [SerializeField] float speeds = 2f;


    void Update()
    {
        float x = Mathf.Sin(UnityEngine.Time.time * speeds) * groter; //Makes it move accordingly and smoothly on the x as
        transform.position = new Vector3(x, transform.position.y, transform.position.z); //Object gets new transform position
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject) //If bullet hits 
        {
            print("triggerMuur"); //animation dummy falls
            //gameObject.SetActive(false);
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == muurLayer)
        {
        }
            print("CollisionMuur");
    }

}
