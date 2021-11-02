using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private float initAngle;


    // Update is called once per frame
    void Update()
    {   
        initAngle += 10f * Mathf.Deg2Rad * Time.deltaTime;

        var distance = Vector3.Distance(transform.position, origin.position);
        var newX = origin.position.x + (distance * Mathf.Cos(initAngle));
        var newZ = origin.position.z + (distance * Mathf.Sin(initAngle));

        transform.position = new Vector3(newX, 0f, newZ);
    }
}
