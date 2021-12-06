    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendJumpMTargetStart : MonoBehaviour
{
    public Animator Anim;
    public KeyCode JumpTriggerKey;
    public string JumpFromThisState, JumpState, JumpTrigger;
    AnimatorStateInfo animInfo;
    AnimatorTransitionInfo animTransitionInfo;

    int jumpFromThisStateHash, jumpStateHash;
    string toJumpTransitionName;

    public Transform matchTransform;
    public Vector3 matchTargetPositionWeight;
    public float matchTargetRotationWeight;
    public float matchTargetStart;
    public float matchTargetEnd;
    public bool useMatchTarget = true;

    void Start()
    {
        //Take the name of the state and convert it into an integer so we can use it as a reference
        jumpFromThisStateHash = Animator.StringToHash(JumpFromThisState);
        jumpStateHash = Animator.StringToHash(JumpState);
        toJumpTransitionName = JumpFromThisState + " -> " + JumpState;
    }

    void Update()
    {
        animInfo = Anim.GetCurrentAnimatorStateInfo(0);
        animTransitionInfo = Anim.GetAnimatorTransitionInfo(0);
        bool isInTransition = Anim.IsInTransition(0);

        int currAnimStateHash = animInfo.shortNameHash;
        if (currAnimStateHash == jumpFromThisStateHash &&
            Input.GetKeyDown(JumpTriggerKey) && !isInTransition)
            Anim.SetTrigger(JumpTrigger);
        
        if (useMatchTarget)
        {
            if (currAnimStateHash == jumpStateHash || (animTransitionInfo.IsName(toJumpTransitionName)) && currAnimStateHash == jumpFromThisStateHash)
            {
                Anim.MatchTarget(
                    matchTransform.position,
                    matchTransform.rotation,
                    AvatarTarget.RightFoot,
                    new MatchTargetWeightMask(matchTargetPositionWeight, matchTargetRotationWeight),
                    matchTargetStart, 
                    matchTargetEnd
                );
            }
        }
    }
}
