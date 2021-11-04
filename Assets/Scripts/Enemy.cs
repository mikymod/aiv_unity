using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float power;

    void Awake()
    {
        power = Random.Range(0, 100);  
    }
}
