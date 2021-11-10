using UnityEngine;
using System.Collections;

public enum  facingOrientation{up, down, forward, back, left, right}

public class CameraFacingBillboard : MonoBehaviour
{
	public Camera cam;
	public facingOrientation FromRot_OR_LockAxis;
	public float rotateTowardsInc = 100f;
	public bool lockAxis, smooth;

	void Update()
	{
		//Calculate the direction to the camera. dirToCam is a vector
		//going from our position to the camera
		Vector3 dirToCam = cam.transform.position - transform.position;

		Vector3 fromRot_OR_LockAxis = Vector3.zero;
		if (FromRot_OR_LockAxis == facingOrientation.up)
			fromRot_OR_LockAxis = Vector3.up;
		else if (FromRot_OR_LockAxis == facingOrientation.down)
			fromRot_OR_LockAxis = Vector3.down;
		else if (FromRot_OR_LockAxis == facingOrientation.forward)
			fromRot_OR_LockAxis = Vector3.forward;
		else if (FromRot_OR_LockAxis == facingOrientation.back)
			fromRot_OR_LockAxis = Vector3.back;
		else if (FromRot_OR_LockAxis == facingOrientation.left)
			fromRot_OR_LockAxis = Vector3.left;
		else if (FromRot_OR_LockAxis == facingOrientation.right)
			fromRot_OR_LockAxis = Vector3.right;

        Quaternion finalRotation;
		if (lockAxis) {
            //Use of LookRotation(): we specify what direction we want to look at,
            //	and what is our up vector.
            //	In this case our forward vector is rotated in order to match (dirToCam).normalized direction
            finalRotation = Quaternion.LookRotation (dirToCam, fromRot_OR_LockAxis);
		} else {
            //Use of FromToRotation(). Creates a rotation wich rotates from fromDirection to toDirection.
            finalRotation = Quaternion.FromToRotation (fromRot_OR_LockAxis, dirToCam);
		}
        if(smooth){
            //Use of RotateTowards(): we specify fromRotation and toRotation, and how
			//	many degrees we want to increase our rotation
			transform.rotation = Quaternion.RotateTowards (	transform.rotation,
                                                            finalRotation,
															rotateTowardsInc * Time.deltaTime);
		}
        else
        {
            transform.rotation = finalRotation;
        }
	}
}