﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float DestroyAfter = 2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyAfter);
    }
}
