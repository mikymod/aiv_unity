using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spherecastTest : MonoBehaviour {
	public float maxDistance, sphereRadious;
	public Transform axesPrefab;
	public bool raycastAll;
	Transform originT;
	Vector3 dir;
	RaycastHit hitInfo;
	RaycastHit[] hitsInfo;
	int LayerMask;
	Ray customRay;


	// Use this for initialization
	void Start () {
	}
	
	void Update () {
		//customRay = new Ray (transform.position, transform.forward);

		//Returns a ray going from camera through a screen point.
		customRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(customRay.origin, customRay.direction * maxDistance, Color.yellow);


		//I can use my customRay to init the Raycast function, or we can specify origin and direction
		//Physics.Raycast (transform.position, transform.forward, out hitInfo, maxDistance)
		//infinity distance
		//Physics.Raycast (customRay, out hitInfo)
		if (!raycastAll) {
			//We are searching for the first hitted obj along the ray
			if (Physics.SphereCast (customRay, sphereRadious, out hitInfo, maxDistance)) {
				Debug.Log ("Something is hitted at " + hitInfo.point);
				axesPrefab.position = hitInfo.point;
				axesPrefab.LookAt (hitInfo.point + hitInfo.normal);
			} else
				Debug.Log ("Raycast didn't hit anything");
		} else {
			//We are searching for ALL the hitted objs along the ray
			hitsInfo = Physics.SphereCastAll (customRay, sphereRadious, maxDistance);
			if(hitsInfo.Length > 0){
				Debug.Log ("I hitted "+hitsInfo.Length+" object(s):");
				foreach (RaycastHit currHitInfo in hitsInfo) {
					Debug.Log ("---["+currHitInfo.collider.name+"] at "+ currHitInfo.point);
				}
			} else
				Debug.Log ("Raycast didn't hit anything");
		}
	}
}
