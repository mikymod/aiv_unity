using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedPlaneDrawer : MonoBehaviour
{
    public Transform StartU, EndU, StartV, EndV;
    public GameObject DotPrefab;
    public int Resolution = 10;

    void Start()
    {
        //StartU and StartV must be the same. Force this condition here.
        StartU.position = StartV.position;

        float step = 1.0f / Resolution;

        Vector3 u = EndU.position - StartU.position;
        Vector3 v = EndV.position - StartV.position;

        for (int i = 0; i < Resolution; i++)
        {
            for (int j = 0; j < Resolution; j++)
            {
                Vector3 p = StartV.position + u * (step * i) + v * (step * j);
                Instantiate(DotPrefab, p, Quaternion.identity, transform);
            }
        }

    }
}
