using UnityEngine;
using System.Collections;

public enum pingPongState {FORWARD, BACKWARD}

public class lerpPingPong : MonoBehaviour
{
	public Transform startPos, endPos;
	private Transform tmpPos;
	public float duration = 1;
	public lerpType type;

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

	void FixedUpdate()
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

		fraction = customLerp.getFraction (currTime, duration, type);
		transform.position = Vector3.Lerp(startPos.position, endPos.position, fraction);
	}
}
