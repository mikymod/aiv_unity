using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class CalculateForce : MonoBehaviour
{
    public float mass = 30.0f;

    public Transform[] Wheels;

    void Update()
    {
        Vector3 W = mass * new Vector3(0, 9.8f, 0);
        Debug.DrawLine(transform.position, transform.position - W, Color.blue);

        Vector3 O = transform.position;
 
        var proj = Vector3.Project(-W, transform.forward);
        Debug.DrawLine(transform.position, transform.position + proj, Color.red);

        // transform.Translate(proj * Time.deltaTime);
        transform.position += proj * Time.deltaTime;

        // TODO: Rotate wheels
    }
}
