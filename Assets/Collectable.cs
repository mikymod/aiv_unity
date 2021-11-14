using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static event Action<int> OnPickUp;
    
    [SerializeField][Range(0.1f, 2f)] private float distanceToPickUp = 1f;
    [SerializeField][Range(-1, 1)] private int points = 1;
    public Transform Target { get; set; }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, Target.position);

        if (distance <= distanceToPickUp)
        {
            OnPickUp.Invoke(points);
            Destroy(gameObject);
        }        
    }
}
