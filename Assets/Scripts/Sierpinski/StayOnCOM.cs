using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnCOM : MonoBehaviour
{
    private Transform AB, BC, CA;
    private float offsetY;

    public void SetPoints(Transform AB, Transform BC, Transform CA, float offset)
    {
        this.AB = AB;
        this.BC = BC;
        this.CA = CA;
        this.offsetY = offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (AB.position + BC.position + CA.position) / 3f + Vector3.up * offsetY;
    }
}
