using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicTimer : MonoBehaviour {
    public bool stopOnCollisionEnter = true;
    public int ID;
    float startTime;


    void OnEnable () {
        startTime = Time.time;
	}

    void OnCollisionEnter()
    {
        if (stopOnCollisionEnter)
            Debug.Log("physicTimer[" + ID + "]: " + (Time.time - startTime));
    }
}
