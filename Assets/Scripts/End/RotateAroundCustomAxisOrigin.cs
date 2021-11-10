using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCustomAxisOrigin : MonoBehaviour
{
    public Transform ObjToRotate;
    public Transform ObjOnRotationAxis;
    public float RotationAngle = 0;
    public bool RotateUsingPosition = true;
    public bool RotateUsingOrientation = false;

    void Update()
    {
        //---Quaternion * Vector: we want to rotate a 3D point alpha degrees
        //  around an axes (q1 stores the axes and the degrees)
        Vector3 Axis = ObjOnRotationAxis.position - Vector3.zero;
        Quaternion q = Quaternion.AngleAxis(RotationAngle * Time.deltaTime, Axis.normalized);

        if (RotateUsingPosition) { 
            //This rotates ObjToRotate around q.axis by q.degrees
            //  - ObjToRotate rotates around q.axis changing its position, NOT ROTATION!
            //  - q.axis is an axis that passes through the origin!
            ObjToRotate.position = q * ObjToRotate.position;
            Debug.DrawLine(Vector3.zero - Axis * 5, Vector3.zero + Axis * 5, Color.yellow);
        }
        if (RotateUsingOrientation) {
            //This rotates ObjToRotate around q.axis by q.degrees
            //  - ObjToRotate rotates around q.axis changing its ORIENTATION!
            //  - q.axis is an axis that passes through ObjToRotate PIVOT!
            ObjToRotate.rotation = q * ObjToRotate.rotation;
            Debug.DrawLine(ObjToRotate.position - Axis * 5, ObjToRotate.position + Axis * 5, Color.green);
        }
    }
}
