using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Instantiate2DLabyrinth : MonoBehaviour
{
    public Transform parent;
    public int nx, nz;
    public float offsetX, offsetZ;
    public GameObject prefab;
    public NavMeshSurface surface;

    Vector3 startT, currT;

    void OnEnable()
    {
        startT = Vector3.zero;
        currT = Vector3.zero;
        for (int i = 0; i < nx; i++)
        {
            for (int j = 0; j < nz; j++)
            {
                GameObject go;
                if (parent != null)
                    go = Instantiate(prefab, parent);
                else
                    go = Instantiate(prefab);
                float[] rotations = {0, 90, 180, 270};
                go.transform.localPosition = currT;
                go.transform.rotation = Quaternion.Euler(0, rotations[Random.Range(0, 4)], 0);
                currT = new Vector3(currT.x + offsetX, currT.y, currT.z);
            }
            currT = new Vector3(startT.x, currT.y, currT.z + offsetZ);
        }

        surface.BuildNavMesh();
    }
}
