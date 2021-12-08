using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBoxInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int numPrefabs;
    [SerializeField] private float offsetY = 2f;
    [SerializeField] private float offsetZ = 2f;

    // private List<GameObject> cubeBoxList = new List<GameObject>();

    // Quaternion[] rotations = {
    //     Quaternion.AngleAxis(0, Vector3.up),
    //     Quaternion.AngleAxis(90, Vector3.up),
    //     Quaternion.AngleAxis(-90, Vector3.up),
    // };

    void Start()
    {
        var curPosition = transform.position;
        for (int i = 1; i <= numPrefabs; i++)
        {
            Quaternion rotation;
            if (i % 2 == 0)
            {
                rotation = Quaternion.AngleAxis(0, Vector3.up);
            }
            else
            {
                rotation = Random.Range(0, 2) == 0 ? Quaternion.AngleAxis(90, Vector3.up) : Quaternion.AngleAxis(-90, Vector3.up);
            }
            
            Instantiate(prefab, new Vector3(curPosition.x, curPosition.y + offsetY * i, curPosition.z + offsetZ * i), rotation);
            // cubeBoxList.Add(newGO);
        }
    }
}
