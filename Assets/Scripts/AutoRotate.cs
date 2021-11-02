using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
	public bool performUpdate;
	public float angle;

	void Update () {
		if (performUpdate) {
			transform.Rotate (0, angle * Time.deltaTime, 0);
		}
	}
}
