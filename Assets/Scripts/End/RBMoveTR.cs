using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RBMoveTR : MonoBehaviour
{
    public float speedT = 20;
    public float speedR = 150;
    public string HAxisName = "Horizontal";
    public string VAxisName = "Vertical";
    public bool UseForce;
    float HVal, VVal;
    Rigidbody rb;
    Vector3 lastPos;
    Quaternion lastRot;
 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPos = transform.position;
        lastRot = transform.rotation;
    }
    void Update()
    {
        HVal = Input.GetAxis(HAxisName) * speedR * Time.deltaTime;
        VVal = Input.GetAxis(VAxisName) ;
        lastPos = transform.position;
        lastRot = transform.rotation;
    }
    private void FixedUpdate()
    {
        //Use fixedDeltaTime instead of deltaTime
        Quaternion offsetRot = Quaternion.Euler(0, HVal * speedR * Time.fixedDeltaTime, 0);
        //Here we create a Vector3 with z != 0...
        Vector3 offsetPos = new Vector3(0, 0, VVal * speedT * Time.fixedDeltaTime);
        //...then we must rotate the 'forward' offsetPos in the right direction 
        //q * Vector3 (lastPos)
        offsetPos = (offsetRot * lastRot) * offsetPos;
        //In FixedUpdate it is better to move the rb, not the Transform, because we want that our Player
        //  interacts with other cubes rb.
        //Since the last time we rendered our Player was in an Update function, we must use lastPos/Rot as
        //  starting pos/rot reference
        //q * lastq (lastRot)
        rb.MoveRotation(offsetRot * lastRot);
        if(!UseForce)
            rb.MovePosition(lastPos + offsetPos); 
        else if(VVal != 0)
        {
            //Use High value for speedT: >10K
            //set isKinematic = false
            //Remove RB on cubes to see the player stopping when collides with them!
            Vector3 force = transform.TransformDirection(Vector3.forward) * VVal * speedT * Time.fixedDeltaTime;
            Debug.Log($"Forward force: {force}");
            rb.AddForce(force);
        }
    }
}
