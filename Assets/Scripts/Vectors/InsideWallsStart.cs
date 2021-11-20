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
    private bool canMove;

    private void Start()
    {
        cam = Camera.main;
        Vector3[] vertices = Quad.GetComponent<MeshFilter>().mesh.vertices;

        plane = new Plane(Quad.transform.TransformPoint(vertices[0]),
                            Quad.transform.TransformPoint(vertices[1]),
                            Quad.transform.TransformPoint(vertices[2]));

        //Fill in wallsNormals with the first normal in the array GetComponent<MeshFilter>().mesh.normals
        //i.e. wallsNormals[0] will contain the first normal of the Quad Walls[0]
        wallsNormals = new Vector3[Walls.Length];
        for (int i = 0; i < Walls.Length; i++)
        {
            wallsNormals[i] = Walls[i].transform.TransformDirection(Walls[i].GetComponent<MeshFilter>().mesh.normals[0]);
        }
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

                canMove = true;

                //Check if the hitPoint is inside the walls using Dot product between C and N, where
                //  - C is the vector from the hitPoint to the Wall
                //  - N is the wall normal
                //If the hitPoint is inside the wall, then move the redSphere
                for (int i = 0; i < Walls.Length; i++)
                {
                    var normal = wallsNormals[i];
                    var proj = Vector3.Dot(normal.normalized, (hitPoint - Walls[i].transform.position).normalized);
                    Debug.DrawLine(hitPoint, Walls[i].transform.position, Color.red);
                    Debug.DrawLine(Walls[i].transform.position, Walls[i].transform.position + normal, Color.green);
                    
                    if (proj < 0f)
                    {
                        canMove = false;
                        break;
                    }

                    Debug.Log(proj);
                }

                if (canMove)
                {
                    HitPointObj.transform.position = hitPoint;
                }
            }
        }
    }
}
