using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColumnFollower : MonoBehaviour
{
    public Transform PartToFollow;
    public float speed = 5f;
    private Vector3 distance;

    void Start()
    {
        distance = transform.position - PartToFollow.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PartToFollow.position + distance, Time.deltaTime * speed);
    }
}
