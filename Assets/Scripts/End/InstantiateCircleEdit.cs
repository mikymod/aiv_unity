using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class InstantiateCircleEdit : MonoBehaviour
{
    public bool instantiateN, destoryAll;
    public Transform parent;
    public int n;
    public bool inside, outsideUniform, randomRotation, randomScale, randomUniformScale;
    public float randomMinScale, randomMaxScale;
    public float r;
    public GameObject prefab;

    private void Update()
    {
        if (instantiateN)
        {
            instantiateN = false;
            Instantiate();
        }
        if (destoryAll)
        {
            destoryAll = false;
            DestroyAll();
            
        }
    }
    public void DestroyAll()
    {
        int n = transform.childCount;
        List<Transform> children = new List<Transform>();
        for (int i = n - 1; i >= 0; i--)
        {
            if (Application.isPlaying)
                Destroy(transform.GetChild(i).gameObject);
            else
                DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
    public void Instantiate()
    {
        float currUniformA = 0;
        float uniformADelta = 360.0f / (float)n;

        for (int i = 0; i < n; i++)
        {
            GameObject go;
            if (parent != null)
                go = Instantiate(prefab, parent);
            else
                go = Instantiate(prefab);
            if (inside) 
                go.transform.localPosition = Random.insideUnitCircle * r;
            else
            {
                float a, X, Y;
                if (outsideUniform)
                {
                    a = currUniformA;
                    currUniformA += uniformADelta;
                }
                else { 
                    a = Random.Range(0, 359);
                }
                float rad = a * Mathf.PI / 180.0f;
                X = Mathf.Cos(rad) * r;
                Y = Mathf.Sin(rad) * r;
                go.transform.localPosition = new Vector3(X, Y, 0);
            }

            if (randomRotation)
                go.transform.localRotation = Random.rotation;
            if (randomScale) {
                if (randomUniformScale) {
                    float scale = Random.Range(randomMinScale, randomMaxScale);
                    go.transform.localScale = new Vector3(scale, scale, scale);
                }
                else
                    go.transform.localScale = new Vector3(  Random.Range(randomMinScale, randomMaxScale),
                                                            Random.Range(randomMinScale, randomMaxScale),
                                                            Random.Range(randomMinScale, randomMaxScale));
            }
        }
    }
}
