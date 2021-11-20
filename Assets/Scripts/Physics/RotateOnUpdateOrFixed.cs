using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnUpdateOrFixed : MonoBehaviour
{
    public bool rotateOnUpdate = false;
    public Vector3 rotPerSecond = Vector3.zero;

    void Update()
    {
        if (rotateOnUpdate)
            transform.Rotate(rotPerSecond * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (!rotateOnUpdate)
            transform.Rotate(rotPerSecond * Time.deltaTime);
    }
}
