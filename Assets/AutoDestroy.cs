using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float DestroyAfter = 2f;

    void Start()
    {
        Destroy(gameObject, DestroyAfter);        
    }
}
