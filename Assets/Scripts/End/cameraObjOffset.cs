using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class  cameraObjOffset: MonoBehaviour {
	public Transform parentObj;
	public Vector3 offset;

	void LateUpdate () {
        if(parentObj)
		transform.position = parentObj.position + offset;
	}
}
