using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavSpawnerUpdateSurface : MonoBehaviour {
	public Transform objToSpawn;
	public Transform NavSurfaceRootObj;
	public KeyCode kcode;

	void Update () {
		if (Input.GetKeyDown (kcode)) {
			Transform newGOT = Instantiate (objToSpawn, transform.position, transform.rotation);
			newGOT.parent = NavSurfaceRootObj;
		}
	}

}
