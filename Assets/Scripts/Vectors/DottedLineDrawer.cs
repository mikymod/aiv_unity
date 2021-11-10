using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedLineDrawer : MonoBehaviour
{
    public Transform StartPoint, EndPoint;
    public GameObject DotPrefab;
    public float FromRange, ToRange;
    public int PointsNum = 10;

    void Start()
    {
        Vector3[] Pts = VectorUtils.GetLinePoints(StartPoint.position, EndPoint.position, FromRange, ToRange, PointsNum);
        for (int i = 0; i < PointsNum; i++)
        {
            Instantiate(DotPrefab, Pts[i], Quaternion.identity, transform);
        }
        
    }
}
