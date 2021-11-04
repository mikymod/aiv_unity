using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform target;
    public float speed = 1;
    public float duration = 5;

    float timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        var dir = (target.position - transform.position);
        transform.position += dir * speed * Time.deltaTime;
    }
}
