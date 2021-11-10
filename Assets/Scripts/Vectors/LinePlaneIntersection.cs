using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePlaneIntersection : MonoBehaviour
{
    public Transform UBegin, UEnd, VBegin, VEnd, WBegin, WEnd;
    public Transform IntersectPointT;
    float t_w;

    void Update()
    {
        VBegin.position = UBegin.position;
        VectorUtils.GetLinePlaneIntersection(UBegin.position, UEnd.position, VEnd.position, WBegin.position, WEnd.position, out t_w);

        //NB: The intersection is between the line from WBegin-WEnd and the infinite plane described by U, V
        if(t_w > 0 && t_w < 1)
            IntersectPointT.gameObject.SetActive(true);
        else
            IntersectPointT.gameObject.SetActive(false);
        IntersectPointT.position = (WEnd.position - WBegin.position) * t_w + WBegin.position;
    }
}
