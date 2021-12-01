using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendJump_Ex2 : MonoBehaviour
{
    public Animator Anim;
    public KeyCode JumpKey;
    public string JumpFromThisState, JumpTrigger;
    AnimatorStateInfo animInfo;
    AnimatorTransitionInfo animTransitionInfo;
    public CapsuleCollider playerCollider;

    //Take the name of the state and convert it into an integer so we can use it as a reference
    int jumpFromThisStateHash, currAnimStateHash;
    bool isInTransition;
    int toJumpTransitionHash;
    int jumpHash;
    float defaultCollCenterHeight, defaultCollCenterY;

    void Start()
    {
        //Take the name of the state and convert it into an integer so we can use it as a reference
        jumpFromThisStateHash = Animator.StringToHash(JumpFromThisState);
        toJumpTransitionHash = Animator.StringToHash(JumpFromThisState + " -> JumpNotInPlace");
        jumpHash = Animator.StringToHash("JumpNotInPlace");

        defaultCollCenterHeight = playerCollider.height;
        defaultCollCenterY = playerCollider.center.y;   
    }

    void Update()
    {
        animInfo = Anim.GetCurrentAnimatorStateInfo(0);
        animTransitionInfo = Anim.GetAnimatorTransitionInfo(0);
        isInTransition = Anim.IsInTransition(0);

        currAnimStateHash = animInfo.shortNameHash;

        if (currAnimStateHash == jumpFromThisStateHash &&
            Input.GetKeyDown(JumpKey) &&
            !isInTransition)
        {
            Anim.SetTrigger(JumpTrigger);
        }

        // Modify
        if ( currAnimStateHash == jumpHash || (animTransitionInfo.nameHash == toJumpTransitionHash && currAnimStateHash == jumpFromThisStateHash))
        {
            playerCollider.height = Anim.GetFloat("Collider_Height");
            playerCollider.center = new Vector3(playerCollider.center.x, Anim.GetFloat("Collider_CenterY"), playerCollider.center.z);
        }
        else
        {
            playerCollider.height = defaultCollCenterHeight;
            playerCollider.center = new Vector3(playerCollider.center.x, defaultCollCenterY, playerCollider.center.z);
        }
    }
}
