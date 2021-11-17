using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggersEvents : MonoBehaviour {
    public bool DetectAll = true;
    public bool OnEnter = false;
    public bool OnStay = false;
    public bool OnExit = false;

    //This is called as soon as the collision starts
    void OnTriggerEnter(Collider c) {
        if (DetectAll || OnEnter)
            Debug.Log (gameObject.name + " OnTriggerEnter from " + c.gameObject.name);
	}
	//This is called if the Trigger c remains the same of the previous frame
	void OnTriggerStay(Collider c) {
        if (DetectAll || OnStay)
            Debug.Log (gameObject.name + " OnTriggerStay from " + c.gameObject.name);
	}
	//This is called as soon as the collision ends
	void OnTriggerExit(Collider c) {
        if (DetectAll || OnExit)
            Debug.Log (gameObject.name + " OnTriggerExit from " + c.gameObject.name);
	}
}
