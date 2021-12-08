using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMatchTarget : MonoBehaviour
{
    private Transform NextMTargetToReach;
    public Vector3 matchTargetPositionWeight;
    public float matchTargetRotationWeight;
    public float matchTargetStart;
    public float matchTargetEnd;
    public Transform hitDebug;  
    public Transform colliderDebug;  

    private Animator anim;
    private Collider coll;
    private Rigidbody rb;
    private RaycastBoxContainer_Start raycastBox;
    private AnimatorStateInfo animInfo;
    private AnimatorTransitionInfo animTransitionInfo;

    public string JumpFromThisState, JumpState;
    private int jumpFromThisStateHash;
    private int jumpStateHash;
    private string toJumpTransitionName;
    private bool jumpPressed = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        
        //Take the name of the state and convert it into an integer so we can use it as a reference
        jumpFromThisStateHash = Animator.StringToHash(JumpFromThisState);
        jumpStateHash = Animator.StringToHash(JumpState);
        toJumpTransitionName = JumpFromThisState + " -> " + JumpState;

        jumpPressed = false;     
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }

    private void OnAnimatorMove()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        animTransitionInfo = anim.GetAnimatorTransitionInfo(0);
        bool isInTransition = anim.IsInTransition(0);

        int currAnimStateHash = animInfo.shortNameHash;
        if (currAnimStateHash == jumpStateHash && !isInTransition)
        {            
            anim.MatchTarget(
                NextMTargetToReach.position,
                NextMTargetToReach.rotation,
                AvatarTarget.RightHand,
                new MatchTargetWeightMask(matchTargetPositionWeight, matchTargetRotationWeight),
                matchTargetStart,
                matchTargetEnd
            );

            transform.rotation = Quaternion.RotateTowards(transform.rotation, NextMTargetToReach.rotation, 45 * Time.deltaTime);
        }    
    }

    public void EnableGravityAndCollider()
    {
        coll.enabled = true;
        rb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var comp = other.gameObject.GetComponent<SetNextMTargetOnTEnter>();
        if (comp != null)
        {
            comp.TargetToSet = colliderDebug;
            NextMTargetToReach = comp.TargetToSet;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var comp = other.gameObject.GetComponent<SetNextMTargetOnTEnter>();
        if (comp != null)
        {
            comp.TargetToSet = colliderDebug;
            NextMTargetToReach = comp.TargetToSet;
        }

        if (jumpPressed)
        {
            jumpPressed = false;
            
            coll.enabled = false;
            rb.useGravity = false;

            anim.SetTrigger("Jump");
        }       
    }
}
