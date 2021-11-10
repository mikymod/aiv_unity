using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtils
{
    public static Vector2 GetPerp(this Vector2 v)
    {
        return new Vector2(-v.y, v.x);
    }

    public static void GetSegmentIntersection(Vector2 uBegin, Vector2 uEnd, Vector2 vBegin, Vector2 vEnd, out float s_u, out float t_v)
    {
        Vector2 u = uEnd - uBegin;
        Vector2 v = vEnd - vBegin;
        Vector2 c = uBegin - vBegin;
        t_v = Vector2.Dot(u.GetPerp(), c) / Vector2.Dot(u.GetPerp(), v);
        s_u = -Vector2.Dot(v.GetPerp(), c) / Vector2.Dot(v.GetPerp(), u);
        Debug.Log("t, s: " + t_v + "," + s_u);
    }

    //u,v vectors define the plane, w vector defines the line
    //u and v have the same origin (uBegin == vBegin)
    public static void GetLinePlaneIntersection(Vector3 uBegin, Vector3 uEnd, Vector3 vEnd, Vector3 wBegin, Vector3 wEnd, out float t_w)
    {
        t_w = 0;

        //Calculate vector u
        //Calculate vector v
        //Calculate vector n
        //Calculate vector w
        //Calculate t_w
    }

    public static Vector3[] GetLinePoints(Vector3 StartPoint, Vector3 EndPoint, float FromRange, float ToRange, int PointsNum)
    {
        Vector3[] Pts = new Vector3[PointsNum];

        float rangeDist = ToRange-FromRange;
        float step = rangeDist / (PointsNum - 1);
        float currStep = 0;
        for (int i = 0; i < PointsNum; i++)
        {
            Pts[i] = StartPoint + ((EndPoint-StartPoint)*(FromRange+currStep));
            currStep += step;
        }

        return Pts;
    }

    public static Vector3 GetReflection(Vector3 vToReflectBegin, Vector3 vToReflectEnd, Vector3 normal)
    {
        //U is the reflected vector
        Vector3 UEnd = Vector3.zero;

        //Calculate Uend
        
        //Use slide formula
        return UEnd;
    }

}
