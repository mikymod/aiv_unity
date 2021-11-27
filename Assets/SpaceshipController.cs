using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private float yaw, pitch, roll;
    private float hAxis, vAxis, power;
    private Rigidbody rb;
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        yaw = Input.GetAxis("Yaw") * speed;
        pitch = Input.GetAxis("Pitch") * speed;
        roll = Input.GetAxis("Roll") * speed;
        hAxis = Input.GetAxis("Horizontal") * speed;
        vAxis = Input.GetAxis("Vertical") * speed;
        power = Input.GetAxis("Power") * speed;
        

        rb.AddRelativeTorque(new Vector3(yaw, pitch, roll));
        rb.AddRelativeForce(new Vector3(hAxis, vAxis, power));

    }
}
