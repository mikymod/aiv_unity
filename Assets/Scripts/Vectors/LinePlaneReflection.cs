using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePlaneReflection : MonoBehaviour
{
    //use U and V to describe the plane
    //W is the incoming vector
    //WR is the reflected vector
    //N is he plane normal
    public Transform UBegin, VBegin, UEnd, VEnd, WBegin, WEnd, WRBegin, WREnd, NBegin, NEnd;

    void Update()
    {
        Vector3 U = UEnd.position - UBegin.position;
        Vector3 V = VEnd.position - VBegin.position;
        Vector3 W = WEnd.position - WBegin.position;

        Vector3 planeNormal = Vector3.Cross(U,V);
        planeNormal.Normalize();

        //GetLine intersection point
        float t_w;
        VectorUtils.GetLinePlaneIntersection(UBegin.position, UEnd.position, VEnd.position, WBegin.position, WEnd.position, out t_w);
        NBegin.position = WBegin.position + W * t_w;
        NEnd.position = NBegin.position + planeNormal;
        //Normal and reflected vector starts from the same point
        WRBegin.position = NBegin.position;
        WREnd.position = WRBegin.position + VectorUtils.GetReflection(WBegin.position, WEnd.position, planeNormal);
        WREnd.position = new Vector3(WREnd.position.x, WREnd.position.y, WREnd.position.z);
    }
}
