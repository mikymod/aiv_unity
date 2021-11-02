using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPath : MonoBehaviour
{
    public float originX;
    public float originY;
    public float radius;
    public float angle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // X = originX + cos(a * time) * radius;
        // Y = originY + sin(a * time) * radius;
    }
}
