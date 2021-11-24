using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(target.forward, Vector3.up);
    }
}
