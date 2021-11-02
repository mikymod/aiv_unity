using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSin : MonoBehaviour
{
    public float speed = 1;

    void Update()
    {
        Vector3 pos = transform.localPosition;
        transform.localPosition = new Vector3(pos.x, Mathf.Sin(Time.time * speed), pos.z);
    }
}
