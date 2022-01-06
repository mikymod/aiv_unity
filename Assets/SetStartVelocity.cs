using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVelocity : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
}
