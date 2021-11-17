using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDownTest : MonoBehaviour {
	void OnMouseDown () {
		transform.localScale = new Vector3 (transform.localScale.x * 1.2f, transform.localScale.y, transform.localScale.z);
	}
}
