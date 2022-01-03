using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    public Transform Followed { get; set; }
    [SerializeField] private float distance = 3f;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Followed.position) > distance)
        {
            // Update position
            transform.position = Vector3.Lerp(transform.position, Followed.position, speed * Time.deltaTime);
        }
    }
}
