using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveTranslation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var hAx = Input.GetAxis("Horizontal");
        var vAx = Input.GetAxis("Vertical");
        transform.position += new Vector3(hAx, 0, vAx) * 5f * Time.deltaTime;
    }
}
