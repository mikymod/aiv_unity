using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggersEvents : MonoBehaviour {

	//This is called as soon as the collision starts
	void OnTriggerEnter(Collider c) {
		Debug.Log (gameObject.name + " OnTriggerEnter");
		//Destroy (c.gameObject);
	}
	//This is called if the Trigger c remains the same of the previous frame
	void OnTriggerStay(Collider c) {
		Debug.Log (gameObject.name + " OnTriggerStay");
	}
	//This is called as soon as the collision ends
	void OnTriggerExit(Collider c) {
		Debug.Log (gameObject.name + " OnTriggerExit");
	}
}
