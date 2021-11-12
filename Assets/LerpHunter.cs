using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHunter : MonoBehaviour
{
    public Transform hunted;
    public Transform followRange;
    public Transform reachRange;
    private float speed = 0.5f;
    private bool isHunting;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, hunted.position);

        if (distance > followRange.localScale.z / 2)
        {
            isHunting = true;
        }

        if (distance <= reachRange.localScale.z / 2)
        {
            isHunting = false;
        }
        
        if (isHunting)
        {
            transform.position = Vector3.Lerp(transform.position, hunted.position, Time.deltaTime * speed);
        }
    }
}
