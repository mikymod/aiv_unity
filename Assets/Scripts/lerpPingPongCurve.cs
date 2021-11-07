using UnityEngine;
using System.Collections;

public class lerpPingPongCurve : MonoBehaviour
{
	public Transform startPos, endPos;
	private Transform tmpPos;
	public float duration = 1;
	public AnimationCurve curve;

	public pingPongState state;
	private float fraction = 0; 
	private float currTime = 0; 

	void Start(){
		state = pingPongState.FORWARD;
	}
	void ChangeStartEndPos(){
		tmpPos = startPos;
		startPos = endPos;
		endPos = tmpPos;
	}

	void Update()
	{
		if (currTime > duration) {
			state = pingPongState.BACKWARD;
		}
		else if(currTime < 0){
			state = pingPongState.FORWARD;
		}

		if(state == pingPongState.FORWARD)
			currTime += Time.deltaTime;
		else
			currTime -= Time.deltaTime;

		// fraction = customLerp.getFraction (currTime, duration, type);
		fraction = curve.Evaluate(currTime / duration); // currTime / duration => x
		transform.position = Vector3.Lerp(startPos.position, endPos.position, fraction);
	}
}
