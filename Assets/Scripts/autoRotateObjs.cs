using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotateObjs : MonoBehaviour {
	public float angle;
	public bool performUpdateOnCubes;

	public GameObject cubeR;
	public AutoRotate cubeG_autoRotateScript;
	public GameObject cubeB;
	GameObject beautifulNameGO;
	GameObject cubeTaggedGO;

	public void Start(){
		beautifulNameGO = GameObject.Find("beautifulName");
		cubeTaggedGO = GameObject.FindWithTag("cube_tag");
	}

	public void Update () {
		//rotate cubeR using its Transform component
		cubeR.transform.Rotate (0, angle * Time.deltaTime, 0);

		//rotate cubeG using its AutoRotate script component (the public variable here is a pointer to a script)
		cubeG_autoRotateScript.performUpdate = performUpdateOnCubes;
		// cubeG_autoRotateScript.angle = angle;

		//rotate cubeB using its AutoRotate script component (the public variable is a pointer to a GameObject)
		cubeB.GetComponent<AutoRotate>().performUpdate = performUpdateOnCubes;
		// cubeB.GetComponent<AutoRotate>().angle = angle;

		//rotate beautifulNameGO using its Transform component (beautifulNameGO is not hard-linked - found with name)
		beautifulNameGO.transform.Rotate (0, angle * Time.deltaTime, 0);

		//rotate cubeTaggedGO using its Transform component (cubeTaggedGO is not hard-linked - found with tag)
		cubeTaggedGO.transform.Rotate (0, angle * Time.deltaTime, 0);
	}
}
