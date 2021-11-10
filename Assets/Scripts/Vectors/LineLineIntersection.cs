using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLineIntersection : MonoBehaviour
{
    public Transform UBegin, VBegin, UEnd, VEnd;
    public Transform IntersectPointT;

    void Update()
    {
        if(Vector2.Dot(UBegin.position - UEnd.position, VBegin.position - VEnd.position) == 0)
        {
            //No intersection here
            return;
        }
        float t_v, s_u;
        VectorUtils.GetSegmentIntersection(UBegin.position, UEnd.position, VBegin.position, VEnd.position, out s_u, out t_v);

        if(t_v <= 1 && t_v >= 0 && s_u <= 1 && s_u >= 0)
        {
            //There is intersection, otherwise the intersection is outside segment boundaries
            IntersectPointT.gameObject.SetActive(true);
            IntersectPointT.position = (VEnd.position - VBegin.position) * t_v + VBegin.position;
        }
        else
            IntersectPointT.gameObject.SetActive(false);
    }
}
