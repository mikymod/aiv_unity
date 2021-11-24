using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTimeTester : MonoBehaviour
{
    public KeyCode GrowNTimeKey;
    public float Speed = 1;
    public Animator anim;
    float currNTime = 0;


    // Update is called once per frame
    void Update()
    {
        currNTime = Mathf.Clamp(currNTime, 0, 1);
        if (Input.GetKey(GrowNTimeKey))
            currNTime += Time.deltaTime * Speed;
        else
            currNTime -= Time.deltaTime * Speed;
        anim.SetFloat("MTime", currNTime);
    }
}
