using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController_Walk_Run2 : MonoBehaviour {
    public Animator animator;
    public string paramNameTranslate, paramNameRotate;
    public bool sendTranslateParam, sendRotateParam;
    public bool translateRoot, rotateRoot;
    public float rotationBoost = 1, translateBoost = 0.1f;
    public KeyCode ModifierKey;

    public float ModifierBoost = 2f;
    float x, z;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (Input.GetKey(ModifierKey))
            z *= ModifierBoost;

        if (sendTranslateParam)
            animator.SetFloat(paramNameTranslate, z);
        if (sendRotateParam)
            animator.SetFloat(paramNameRotate, x);
    }

    private void OnAnimatorMove()
    {
        if (translateRoot)
            transform.Translate(0, 0, z * translateBoost);
        else
            transform.position = animator.rootPosition;

        if (rotateRoot)
            transform.Rotate(0, x * rotationBoost, 0);
        else
            transform.rotation = animator.rootRotation;
    }

}
