using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummies : MonoBehaviour
{
    PaintSplatter paintSplatter;
    [SerializeField] Animator animator;
    [SerializeField] float grote = 2f;
    [SerializeField] float speed = 2f;

    private void Start()
    {
        animator.enabled = false;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * grote; //Makes it move accordingly and smoothly on the x as
        transform.position = new Vector3(x, transform.position.y, transform.position.z); //Object gets new transform position
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PaintSplatter>()) //If bullet hits
        {
            print("trigger");
            animator.enabled = true; //animation dummy falls
        }
    }
}
