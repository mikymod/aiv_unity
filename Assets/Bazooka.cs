using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    public Transform target;
    public Transform leftHandle;
    public Transform rightHandle;
    public GameObject bazooka;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private Animator anim;
    private Vector3 initLocalPos;
    private Vector3 right;
    private Vector3 left;
    private Quaternion rightRot;
    private Quaternion leftRot;
    private float fire = 0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        initLocalPos = bazooka.transform.localPosition;
    }

    private void Update()
    {
        right = rightHandle.position;
        left = leftHandle.position;
        rightRot = rightHandle.rotation;
        leftRot = leftHandle.rotation;

        // Fire
        if (Input.GetMouseButton(0) && anim.GetFloat("Fire") == 0f)
        {
            var go = Instantiate(bulletPrefab);
            go.transform.position = bulletSpawnPoint.position;
            go.GetComponent<SetStartVelocity>().SetVelocity(bulletSpawnPoint.forward * 10f);
            
            anim.SetFloat("Fire", 1f);
        }
        else
        {
            anim.SetFloat("Fire", 0f, 1f, 6f * Time.deltaTime);
            if (anim.GetFloat("Fire") <= 0.1f)
            {
                anim.SetFloat("Fire", 0f);
            }
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (layerIndex == 0)
        {
            var fire = anim.GetFloat("Fire");
            if (fire == 1f)
            {
                bazooka.transform.localPosition = new Vector3(
                    bazooka.transform.localPosition.x,
                    bazooka.transform.localPosition.y,
                    bazooka.transform.localPosition.z - anim.GetFloat("Fire") * 0.5f
                );
            }
            else
            {
                bazooka.transform.localPosition = Vector3.Lerp(bazooka.transform.localPosition, initLocalPos, 4f * Time.deltaTime);
            }

            anim.SetLookAtWeight(1f, 1f, 1f, 1f, 1f);
            anim.SetLookAtPosition(target.position);
        }
        else if (layerIndex == 1)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, left);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, leftRot);

            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            anim.SetIKPosition(AvatarIKGoal.RightHand, right);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
            anim.SetIKRotation(AvatarIKGoal.RightHand, rightRot);
        }
    }
}
