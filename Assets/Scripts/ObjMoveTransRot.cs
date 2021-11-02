using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveTransRot : MonoBehaviour
{
    public float speed = 5f;
    public float speedRotation = 50f;

    // Update is called once per frame
    void Update()
    {
        var hAx = Input.GetAxis("Horizontal");
        var vAx = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0, hAx, 0) * speedRotation * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, vAx) * speed * Time.deltaTime);
    }
}
