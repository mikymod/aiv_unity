using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// [ExecuteInEditMode]
public class Instantiator2D : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    public int numX, numZ;
    public float offsetX, offsetZ;

    public bool instantiate, destroyAll, instantiatePrefabs;

    private void Start()
    {
        InstantiateN();    
    }

    private void OnDestroy()
    {
        // DestroyAll();    
    }

    void Update()
    {
        if (instantiate)
        {
            instantiate = false;
            InstantiateN();
        }
        if (destroyAll)
        {
            destroyAll = false;
            DestroyAll();
        }        
    }

    private void InstantiateN()
    {
        if (parent == null)
        {
            parent = transform;
        }

        Vector3 currPosition = Vector3.zero;

        for (int x = 0; x < numX; x++)
        {
            currPosition = new Vector3(offsetX * x, currPosition.y, 0);
            
            for (int z = 0; z < numZ; z++)
            {
                currPosition = new Vector3(currPosition.x, currPosition.y, offsetZ * z);

                if (instantiatePrefabs)
                {
                    var go = (GameObject)PrefabUtility.InstantiatePrefab(prefab, parent);
                    go.transform.localPosition = currPosition;
                }
                else
                {
                    var go = Instantiate(prefab, parent);
                    go.transform.localPosition = currPosition;
                }
            }
        }
    }

    private void DestroyAll()
    {
        Transform[] children = parent.GetAllChildren();
        for (int i = children.Length - 1; i >= 0; i--)
        {
            if (Application.isPlaying)
            {
                Destroy(children[i].gameObject);             
            }
            else
            {
                DestroyImmediate(children[i].gameObject);             
            }
        }
    }
}
