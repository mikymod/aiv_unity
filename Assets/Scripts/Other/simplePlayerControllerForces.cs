using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplePlayerControllerForces : MonoBehaviour {
	public float speed = 150f;
    Rigidbody rigidBody;
    public bool addTorque;
    float HVal, VVal;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HVal = Input.GetAxis("Horizontal") * speed;
        VVal = Input.GetAxis("Vertical") * speed;
    }
	//This is done in FixedUpdate, because the player should check its collisions
	void FixedUpdate () {

        Vector3 v = new Vector3(HVal,0,VVal)* speed;
        if(addTorque)
            rigidBody.AddTorque(v, ForceMode.Acceleration);
        else
            rigidBody.AddForce(v, ForceMode.Acceleration);
	}
}
