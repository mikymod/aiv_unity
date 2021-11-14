using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour
{

    [SerializeField] private Transform planet;
    [SerializeField] private Transform pivot;

    [SerializeField] private float range = 30f;
    private float xAxis = 0f;
    private float yAxis = 0f;  

    void Update()
    {
        xAxis += Input.GetAxis("Horizontal");
        yAxis += Input.GetAxis("Vertical");

        // Clamp valus
        xAxis = Mathf.Clamp(xAxis, -range, range);
        yAxis = Mathf.Clamp(yAxis, -range, range);

        var qy = Quaternion.AngleAxis(xAxis, Vector3.up);
        var qx = Quaternion.AngleAxis(yAxis, Vector3.right);       
        var finalRotation = qx * qy;

        var finalPosition = pivot.position - (finalRotation * Vector3.forward * (planet.localScale.z / 2f));
        transform.position = finalPosition;
        transform.rotation = finalRotation;
    }
}
