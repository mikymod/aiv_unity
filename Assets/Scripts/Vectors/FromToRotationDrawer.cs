using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromToRotationDrawer : MonoBehaviour
{
    public Transform FromDir, ToDir, O;
    public Transform ObjToRotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(O.position, FromDir.position, Color.red);
        Debug.DrawLine(O.position, ToDir.position, Color.green);
        Quaternion q = Quaternion.FromToRotation(FromDir.position, ToDir.position);
        float angle;
        Vector3 axis;
        q.ToAngleAxis(out angle, out axis);
        Debug.DrawLine(O.position, axis*5, Color.yellow);
        Debug.Log("ToAngleAxis angle: "+ angle);

        ObjToRotate.rotation = q;
    }
}
