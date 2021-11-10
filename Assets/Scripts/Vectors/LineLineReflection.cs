using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLineReflection : MonoBehaviour
{
    //U is the incoming vector
    //V is the wall
    //W is the reflected vector
    public Transform UBegin, VBegin, UEnd, VEnd, WBegin, WEnd, NBegin, NEnd;

    void Update()
    {
        Vector2 U = UEnd.position - UBegin.position;
        Vector2 V = VEnd.position - VBegin.position;

        Vector2 Vnormal = VectorUtils.GetPerp(V);
        Vnormal.Normalize();

        //GetLine intersection point
        float s_u, t_v;
        VectorUtils.GetSegmentIntersection(UBegin.position, UEnd.position, VBegin.position, VEnd.position, out s_u, out t_v);
        NBegin.position = U * s_u + new Vector2(UBegin.position.x, UBegin.position.y);
        NEnd.position = NBegin.position + new Vector3(Vnormal.x, Vnormal.y, 0);
        //Normal and reflected vector starts from the same point
        WBegin.position = NBegin.position;
        WEnd.position = WBegin.position + VectorUtils.GetReflection(UBegin.position, UEnd.position, Vnormal);
    }
}
