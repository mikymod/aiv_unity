using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformChanger : MonoBehaviour
{
    public Vector3 NewPos;
    public Vector3 NewRot;
    public Vector3 NewScale;

    public bool useLocal;

    void Start()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0 ,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (useLocal)
        {
            transform.localPosition = NewPos;
            transform.localRotation = Quaternion.Euler(NewRot);
        }
        else
        {
            transform.position = NewPos;
            transform.rotation = Quaternion.Euler(NewRot);
        }

        transform.localScale = NewScale;
    }
}
