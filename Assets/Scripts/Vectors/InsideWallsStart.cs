using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideWallsStart : MonoBehaviour
{
    public GameObject Quad, HitPointObj;
    public GameObject[] Walls;
    Vector3[] wallsNormals;

    Plane plane;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        Vector3[] vertices = Quad.GetComponent<MeshFilter>().mesh.vertices;

        plane = new Plane(Quad.transform.TransformPoint(vertices[0]),
                            Quad.transform.TransformPoint(vertices[1]),
                            Quad.transform.TransformPoint(vertices[2]));

        //Fill in wallsNormals with the first normal in the array GetComponent<MeshFilter>().mesh.normals
        //i.e. wallsNormals[0] will contain the first normal of the Quad Walls[0]
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            float t = 0;
            if(plane.Raycast(ray, out t))
            {
                Vector3 hitPoint = ray.GetPoint(t);
                Vector3 localHPoint = Quad.transform.InverseTransformPoint(hitPoint);

                //Check if the hitPoint is inside the walls using Dot product between C and N, where
                //  - C is the vector from the hitPoint to the Wall
                //  - N is the wall normal
                //If the hitPoint is inside the wall, then move the redSphere
            }
        }
    }
}
