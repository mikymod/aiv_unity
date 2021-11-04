using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Instantiator1D : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    public int amount;
    public Vector3 deltaPosition, deltaScale, deltaRotation;

    public bool instantiateN, destroyAll, instantiatePrefabs;

    void Start()
    {

    }

    private void Update()
    {
        if (instantiateN)
        {
            instantiateN = false;
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
        Vector3 currRotation = Vector3.zero;
        Vector3 currScale = Vector3.one;

        for (int i = 0; i < amount; i++)
        {
            if (instantiatePrefabs)
            {
                var go = (GameObject)PrefabUtility.InstantiatePrefab(prefab, parent);
                go.transform.position = currPosition;
                go.transform.rotation = Quaternion.Euler(currRotation);
                go.transform.localScale = currScale;
            }
            else
            {
                var go = Instantiate(prefab, currPosition, Quaternion.Euler(currRotation), parent);
                go.transform.localScale = currScale;
            }

            currPosition += deltaPosition;
            currRotation += deltaRotation;
            currScale = Vector3.Scale(currScale, deltaScale);
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
