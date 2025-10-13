using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField] float grote = 2f;
    [SerializeField] float speed = 2f;

    void Update()
    {
        float z = Mathf.Sin(UnityEngine.Time.time * speed) * grote; //Makes it move accordingly and smoothly on the x as
        transform.position = new Vector3(transform.position.x, transform.position.y, z); //Object gets new transform position
    }
}

