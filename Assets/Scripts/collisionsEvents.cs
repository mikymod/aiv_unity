using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionsEvents : MonoBehaviour {
    public bool DetectAll = true;
    public bool OnEnter = false;
    public bool OnStay = false;
    public bool OnExit = false;

    //This is called as soon as the collision starts
    void OnCollisionEnter(Collision c) {
        if(DetectAll || OnEnter)
    		Debug.Log (gameObject.name + " OnCollisionEnter with " + c.gameObject.name);
	}
	//This is called if the Collision c remains the same of the previous frame
	void OnCollisionStay(Collision c) {
        if (DetectAll || OnStay)
            Debug.Log (gameObject.name + " OnCollisionStay with " + c.gameObject.name);
    }
	//This is called as soon as the collision ends
	void OnCollisionExit(Collision c) {
        if (DetectAll || OnExit)
            Debug.Log (gameObject.name + " OnCollisionExit with " + c.gameObject.name);
	}
}
