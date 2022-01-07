using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2nd Lesson on Feet IK - start point
public class IKFootHandStart : MonoBehaviour
{
    public bool MoveRootTransformY;
    [Header("Feet IK")]
    public bool FeetIK;
    public bool FeetRotationIK;
    //If we want to move the body COM toward front leg if we are in IDLE and the slope is positive, backward otherwise, to add realism
    public bool MoveCOM;
    //The ray from the L/RFoot to the floor
    public float FootRayCastOffset = 0.3f;
    //The foot should be placed where we hit the ground + FootOffset upward
    public Vector3 FootOffset = new Vector3(0, 0.1f, 0);
    //These helpers help us to calculate foot rotation
    public Transform LF_Helper, RF_Helper;
    public Vector3 LFootHelperOffset = new Vector3(0, 0, 0.5f);
    public Vector3 RFootHelperOffset = new Vector3(0, 0, 0.5f);
    //Highlight the raycast hitting point for each foot
    public Transform LF_HitDebug, RF_HitDebug;
    public LayerMask FeetRaycastMask;
    //If MoveCOM == true, we'll move body COM a max amount of maxDistanceFromCOM, depending on maxOffsetBetweenFeet
    public float maxOffsetBetweenFeet = .5f, maxDistanceFromCOM = .2f;

    RaycastHit footHit;
    Transform leftFoot, rightFoot;
    float lFootW, rFootW;
    //Final position and rotation
    Vector3 lfPos, rfPos;
    Quaternion lfRot, rfRot;

    Animator anim;
    //We'll move the root transform Y value depending on the raycast from the hips, downward
    Transform hips;
    bool isFalling;

    [Header("Hand IK")]
    public bool handIK;
    public Transform leftShoulder;
    public Transform rightShoulder;
    public float pushingDistanceThreshold;
    public Transform LH_Helper, RH_Helper;
 	public LayerMask collisionMask = 0;


    void Start()
    {
        anim = GetComponent<Animator>();

        leftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        rightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
        hips = anim.GetBoneTransform(HumanBodyBones.Hips);

        LF_Helper.parent = leftFoot;
        LF_Helper.localPosition = LFootHelperOffset;
        RF_Helper.parent = rightFoot;
        RF_Helper.localPosition = RFootHelperOffset;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (anim == null)
            return;

        if (MoveRootTransformY)
            FindBodyPosition();//Adjust RootTransform.y

        if (isFalling)
            return;

        if (FeetIK)
        {
            FindFootPosition(leftFoot, LF_Helper, ref lfPos, ref lfRot);
            FindFootPosition(rightFoot, RF_Helper, ref rfPos, ref rfRot);

            lFootW = rFootW = 1;
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, lFootW);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rFootW);
            anim.SetIKPosition(AvatarIKGoal.LeftFoot, lfPos);
            anim.SetIKPosition(AvatarIKGoal.RightFoot, rfPos);

            if (FeetRotationIK)
            {
                anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, lFootW);
                anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rFootW);
                anim.SetIKRotation(AvatarIKGoal.LeftFoot, lfRot);
                anim.SetIKRotation(AvatarIKGoal.RightFoot, rfRot);
            }
        }

        //Adjust anim.bodyPosition
        if (MoveCOM)
        {
            float lOffsetPos = lfPos.y - transform.position.y;
            float rOffsetPos = rfPos.y - transform.position.y;
            float COMFraction = Mathf.Min(Mathf.Abs(lOffsetPos - rOffsetPos), maxOffsetBetweenFeet) / maxOffsetBetweenFeet;
            COMFraction *= maxDistanceFromCOM;

            // Idle pose has right foot behind left
            if (lOffsetPos < rOffsetPos)
            {
                COMFraction *= -1;
            }

            anim.bodyPosition = anim.bodyPosition + transform.forward * COMFraction;
        }

        if (handIK)
        {   
            RaycastHit leftHit = new RaycastHit();
            var leftCollision = Physics.Raycast(leftShoulder.position, transform.forward, out leftHit, pushingDistanceThreshold, collisionMask);
            Debug.DrawRay(leftShoulder.position, transform.forward, Color.white);
            LH_Helper.position = leftShoulder.position + transform.forward * pushingDistanceThreshold;

            RaycastHit rightHit = new RaycastHit();
            var rightCollision = Physics.Raycast(rightShoulder.position, transform.forward, out rightHit, pushingDistanceThreshold, collisionMask);
            Debug.DrawRay(rightShoulder.position, transform.forward, Color.white);
            RH_Helper.position = rightShoulder.position + transform.forward * pushingDistanceThreshold;

            if (leftCollision && rightCollision)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f - leftHit.distance);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f - rightHit.distance);
                anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHit.point);
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHit.point);

                anim.SetBool("Pushing", true);
            }
            else
            {
                anim.SetBool("Pushing", false);
            }
        }
    }

    void FindFootPosition(Transform t, Transform t_helper, ref Vector3 targetPosition, ref Quaternion targetRotation)
    {
        RaycastHit hit;
        Vector3 origin = t.position + Vector3.up * FootRayCastOffset;
        Debug.DrawRay(origin, Vector3.down, Color.yellow);

        if (Physics.Raycast(origin, Vector3.down, out hit, 1, FeetRaycastMask))
        {
            targetPosition = hit.point + FootOffset;

            if (FeetRotationIK)
            {
                Vector3 dir = t_helper.position - t.position;
                dir.y = 0;
                Quaternion rot = Quaternion.LookRotation(dir);
                targetRotation = Quaternion.FromToRotation(Vector3.up, hit.normal) * rot;
            }
        }
    }

    void FindBodyPosition()
    {
        RaycastHit hit;
        Vector3 origin = hips.position;
        Debug.DrawRay(origin, Vector3.down * 2, Color.yellow);
        if (Physics.Raycast(origin, Vector3.down, out hit, 10, FeetRaycastMask))
        {
            if (Vector3.Distance(hit.point, transform.position) > 2)
            {
                isFalling = true;
            }
            else
            {
                isFalling = false;
            }

            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
        else
        {
            isFalling = true;
        }
    }
}
