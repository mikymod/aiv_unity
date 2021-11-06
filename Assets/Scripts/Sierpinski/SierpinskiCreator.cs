using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SierpinskiCreator : MonoBehaviour
{
    public Transform A, B, C;
    public GameObject middlePointPrefab;
    // private Transform AB, BC, CA;

    public GameObject centerPointPrefab;
    private Transform D;

    void Start()
    {
        GenerateTriangle(A, B, C);
    }

    private void GenerateTriangle(Transform A, Transform B, Transform C)
    {
        var ABGO = Instantiate(middlePointPrefab, (B.position + A.position) * 0.5f, Quaternion.identity);
        ABGO.GetComponent<StayBetween2Objs>().SetPoints(A, B, 0);

        var BCGO = Instantiate(middlePointPrefab, (C.position + B.position) * 0.5f, Quaternion.identity);
        BCGO.GetComponent<StayBetween2Objs>().SetPoints(B, C, 0);

        var CAGO = Instantiate(middlePointPrefab, (A.position + C.position) * 0.5f, Quaternion.identity);
        CAGO.GetComponent<StayBetween2Objs>().SetPoints(C, A, 0);

        var DGO = Instantiate(centerPointPrefab, (ABGO.transform.position + BCGO.transform.position + CAGO.transform.position) / 3f, Quaternion.identity);
        DGO.GetComponent<StayOnCOM>().SetPoints(ABGO.transform, BCGO.transform, CAGO.transform, 0);
    }
}
