using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CalculateForce : MonoBehaviour
{
    public float mass = 30.0f;


    void Update()
    {
        Vector3 W = mass * new Vector3(0, 9.8f, 0);
        Debug.DrawLine(transform.position, transform.position - W, Color.blue);
    }
}
