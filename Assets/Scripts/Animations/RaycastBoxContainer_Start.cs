using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBoxContainer_Start : MonoBehaviour
{
    public Transform RayStart;
    public float RayLen;
    public Transform HitDebugT;
    public Transform ColliderDebugT;
    bool Hitted = false;
    RaycastHit raycastHit;
    Ray ray;

    void Update()
    {
        Debug.DrawLine(RayStart.position, RayStart.position + transform.forward * (RayLen == 0 ? 100 : RayLen), Color.yellow);

        ray = new Ray(RayStart.position, transform.forward);

        if (RayLen != 0)
            Hitted = Physics.Raycast(ray, out raycastHit, RayLen);
        else
            Hitted = Physics.Raycast(ray, out raycastHit);

        if (Hitted)
        {
            HitDebugT.position = raycastHit.point;
            ColliderDebugT.position = new Vector3(HitDebugT.position.x, raycastHit.collider.bounds.center.y + raycastHit.collider.bounds.size.y / 2f, HitDebugT.position.z);
            ColliderDebugT.rotation = Quaternion.LookRotation(-raycastHit.normal, Vector3.up);
        }
    }
}
