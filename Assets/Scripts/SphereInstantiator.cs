using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SphereInstantiator : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    public int numObjects = 10;
    public bool inside = false;
    public bool randomRotation= false;
    public bool randomScale = false;
    public bool randomUniformScale = false;
    public float randomMinScale;
    public float randomMaxScale;
    public float radius = 10;

    public bool instantiate, destroyAll, instantiatePrefabs;

    // Update is called once per frame
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
        float uniformScale = 0;
        if (randomUniformScale)
        {
            uniformScale = Random.Range(randomMinScale, randomMaxScale);
        }        

        for (int i = 0; i < numObjects; i++)
        {
            GameObject go;
            if (instantiatePrefabs)
            {
                go = (GameObject)PrefabUtility.InstantiatePrefab(prefab, parent);
            }
            else
            {
                go = Instantiate(prefab, parent);
            }

            if (inside)
            {
                go.transform.position = GetNextRandomPositionInsideSphere();
            }
            else
            {
                go.transform.position = GetNextRandomPositionOnSphere();
                
            }

            if (randomRotation)
            {
                go.transform.rotation = Random.rotation;
            }   

            if (randomScale)
            {
                if (randomUniformScale)
                {
                    go.transform.localScale = new Vector3(uniformScale, uniformScale, uniformScale);
                }
                else
                {
                    go.transform.localScale = new Vector3(
                        Random.Range(randomMinScale, randomMaxScale),
                        Random.Range(randomMinScale, randomMaxScale),
                        Random.Range(randomMinScale, randomMaxScale)
                    );
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

    private Vector3 GetNextRandomPositionInsideSphere()
    {
        return Random.insideUnitSphere * radius;
    }

    private Vector3 GetNextRandomPositionOnSphere()
    {
        return Random.onUnitSphere * radius;
    }
}
