using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererOps : MonoBehaviour {
    LineRenderer lr;

    void Start () {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 4;
        lr.SetPosition(0, new Vector3(-2, 2, 0));
        lr.SetPosition(1, new Vector3(-2, 0, 0));
        lr.SetPosition(2, new Vector3(2, 0, 0));
        lr.SetPosition(3, new Vector3(2, 2, 0));
        lr.loop = true;
        lr.startColor = Color.blue;
    }
}
