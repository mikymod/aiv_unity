using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateAxis : MonoBehaviour {
	public Vector3 AnglesPerSecond;

	void Update () {
        transform.Rotate (AnglesPerSecond.x * Time.deltaTime, AnglesPerSecond.y * Time.deltaTime, AnglesPerSecond.z * Time.deltaTime);
	}
}
