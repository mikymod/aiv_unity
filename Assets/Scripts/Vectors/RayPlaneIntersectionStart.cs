using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPlaneIntersectionStart : MonoBehaviour
{
    public GameObject Corner0Obj, Corner1Obj, Corner2Obj;
    public GameObject Quad, HitPointObj;
    Plane plane;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;        
    }

    void Update()
    {
        Vector3[] vertices = Quad.GetComponent<MeshFilter>().mesh.vertices;
        Debug.Log("V0: "+ vertices[0] + " ,V1: " + vertices[1] + " ,V2: " + vertices[2]);

        plane = new Plane(  Quad.transform.TransformPoint(vertices[0]),
                            Quad.transform.TransformPoint(vertices[1]),
                            Quad.transform.TransformPoint(vertices[2]));
        Corner0Obj.transform.position = Quad.transform.TransformPoint(vertices[0]);
        Corner1Obj.transform.position = Quad.transform.TransformPoint(vertices[1]);
        Corner2Obj.transform.position = Quad.transform.TransformPoint(vertices[2]);

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            float t = 0;
            if(plane.Raycast(ray, out t))
            {
                Vector3 hitPoint = ray.GetPoint(t);
                Vector3 localHPoint;

                //Use Quad.transform.InverseTransformPoint() to know if hitPoint is inside the Quad
                //Move HitPointObj only if hitPoint is inside the Quad

                HitPointObj.transform.position = hitPoint;
            }
        }
    }
}
