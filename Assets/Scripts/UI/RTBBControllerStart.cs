using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTBBControllerStart : MonoBehaviour {
    public float Speed = 1;
    public string H1AxisName, V1AxisName;
    public string H2AxisName, V2AxisName;

    float h1, h2, v1, v2;

    private void Start()
    {
    }

    void Update() {
        h1 = Input.GetAxis(H1AxisName) * Time.deltaTime * Speed;
        v1 = Input.GetAxis(V1AxisName) * Time.deltaTime * Speed;
        h2 = Input.GetAxis(H2AxisName) * Time.deltaTime * Speed;
        v2 = Input.GetAxis(V2AxisName) * Time.deltaTime * Speed;

        //Move Players
        //...

        //Adjust RadarBoundingBox around Players
        //...
    }
}
