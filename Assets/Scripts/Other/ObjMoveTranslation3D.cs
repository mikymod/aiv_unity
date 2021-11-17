using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveTranslation3D : MonoBehaviour
{
    public float speed = 10;
    //public string XAxisName = "XAxis";
    public string YAxisName = "Vertical";
    public string ZAxisName = "Horizontal";

    void Update()
    {
        float XVal = 0;
        //float XVal = Input.GetAxis(XAxisName) * speed * Time.deltaTime;
        float YVal = Input.GetAxis(YAxisName) * speed * Time.deltaTime;
        float ZVal = Input.GetAxis(ZAxisName) * speed * Time.deltaTime;
        transform.Translate(XVal, YVal, ZVal, Space.World);
    }
}
