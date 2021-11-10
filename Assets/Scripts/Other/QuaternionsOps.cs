using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionsOps : MonoBehaviour {
    public float Beta = 90, ManualAlpha;
    public Vector3 axisVector;
    public Transform IdentityT,
        SourceEuler, DestinationEuler,
        ExtractAngleAxis, SetSameAngleAxis, SetSameAngleAxisManual, 
        SetObjRotation, AddObjRotation,
        SourceInverse, DestinationInverse,
        AngleA, AngleB,
        A, B, AB, BA,
        DotA, DotB;

	void Update () {
		Quaternion q1 = Random.rotation;
		Quaternion q2 = Random.rotation;

        //It is better to not use Quaternion constructors, becasue a non-normalized vector is not a valid quaternion:
        Quaternion notValidQuaternion   = new Quaternion(0, 0, 0, 0);
        Quaternion validQuaternion      = Quaternion.identity;
        IdentityT.rotation = validQuaternion;

        //---Back & forth to euler
        //Same as Vector3 eulerVal = ObjSourceEuler.eulerAngles;
        Vector3 eulerVal = SourceEuler.rotation.eulerAngles;
        Debug.Log("eulerVal: " + eulerVal);
        //If you take another gameObj and set its rotation values with this Log
        //values, the 2 obj orientations will match
        Quaternion sameAs_ObjSourceEuler = Quaternion.Euler (eulerVal);
        DestinationEuler.rotation = sameAs_ObjSourceEuler;

        //Extract axis and angle
        float alpha;
		Vector3 axis;
        ExtractAngleAxis.rotation.ToAngleAxis (out alpha, out axis);
        //Draw Extracted axis
        if (ExtractAngleAxis.gameObject.activeSelf)
            Debug.DrawLine(ExtractAngleAxis.position, ExtractAngleAxis.position + axis * 2.5f, Color.yellow);
        SetSameAngleAxis.rotation = Quaternion.AngleAxis (alpha, axis);
        //ManualAlpha should go from 0 to alpha: in this way we can get a confirmation that the yellow axis is the right rotation axis
        if (SetSameAngleAxisManual.gameObject.activeSelf)
            Debug.DrawLine(SetSameAngleAxisManual.position, SetSameAngleAxisManual.position + axis * 2.5f, Color.yellow);
        SetSameAngleAxisManual.rotation = Quaternion.AngleAxis(ManualAlpha, axis);
        Debug.Log("SetSameAngleAxis alpha:" + alpha);

        //To INIT the orientation of an object using these parameters...
        //  - beta degrees of rotation
        //  - rotate around axisVector
        // ...we can build up a quaternion in this way:
        //NB: axisVector is in local space: is an axis passing from the object pivot!
        Quaternion q = Quaternion.AngleAxis (Beta, axisVector);
        Quaternion qOverTime = Quaternion.AngleAxis(Beta * Time.deltaTime, axisVector);

        //And rotate the obj:
        //SetThe obj to the exact rotation we created
        //Draw Rotation axis
        if(SetObjRotation.gameObject.activeSelf)
            Debug.DrawLine(SetObjRotation.position, SetObjRotation.position + axisVector * 2.5f, Color.green);
        SetObjRotation.rotation = q;
        //Add the rotation we created to the obj
        //Draw Rotation axis
        if (AddObjRotation.gameObject.activeSelf)
            Debug.DrawLine(AddObjRotation.position, AddObjRotation.position + axisVector * 2.5f, Color.green);
        AddObjRotation.rotation = qOverTime * AddObjRotation.rotation;

        //Inverse of quaternion
        DestinationInverse.rotation = Quaternion.Inverse (SourceInverse.rotation);

        //---Angle is expressed in degrees
        //AngleA and AngleB quaternions must have the same rotation axis!
        float angleBetween = Quaternion.Angle(AngleA.rotation, AngleB.rotation);
        Debug.Log("angleBetween:" + angleBetween);
        if (AngleA.gameObject.activeSelf)
        {
            AngleA.rotation.ToAngleAxis (out alpha, out axis);
            Debug.DrawLine(AngleA.position, AngleA.position + axis * 2.5f, Color.cyan);
            AngleB.rotation.ToAngleAxis (out alpha, out axis);
            Debug.DrawLine(AngleA.position, AngleA.position + axis * 2.5f, Color.green);
        }

        //---Quaternion * Quaternion: sum of 2 rotations
        //  WARNING: A*B gives us the result as if A is the parent and B is the child.
        //	B*A is not the same result!
        Quaternion Aq = A.rotation;
        Quaternion Bq = B.rotation;
        Quaternion ABq = Aq * Bq;
        Quaternion BAq = Bq * Aq;
        AB.rotation = ABq;
        BA.rotation = BAq;

        //Quaternion.Dot()
        /* 2 unit rotational quaternions will always result in a dot product in the range 0->1, instead of -1->1.
         * https://forum.unity.com/threads/navmeshsurface-min-region-area-settings.606781/
         */
        float QDot = Quaternion.Dot(DotA.rotation, DotB.rotation);
        Debug.Log("Quaternion.Dot:" + QDot);

    }
}
