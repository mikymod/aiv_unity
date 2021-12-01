using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController_Walk2 : MonoBehaviour {
    public Animator animator;
    public string paramNameTranslate, paramNameRotate;
    public bool sendTranslateParam, sendRotateParam;
    public bool translateRoot, rotateRoot;
	public float rotationBoost = 1, translateBoost = 0.1f;
    float x, z;
    private float modifierBoost = 2f;

    void Update ()
    {
      x = Input.GetAxis("Horizontal");
      z = Input.GetAxis("Vertical");

      if (Input.GetKey(KeyCode.LeftShift))
      {
        z *= modifierBoost;
      }
      
      if (sendTranslateParam)
        animator.SetFloat(paramNameTranslate, z);
      if (sendRotateParam)
        animator.SetFloat(paramNameRotate, x);

      
        // transform.Translate(0, 0, z * translateBoost);
        // transform.Rotate(0, x * rotationBoost, 0);

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
