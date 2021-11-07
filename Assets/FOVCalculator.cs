using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVCalculator : MonoBehaviour
{
    public Transform a;
    public Transform b;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float proj = Vector3.Dot(a.position.normalized, b.position.normalized);
        var alpha = Mathf.Acos(proj);
        Debug.Log(alpha * 180 / Mathf.PI);
    }
}
