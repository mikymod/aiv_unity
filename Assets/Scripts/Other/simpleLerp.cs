using UnityEngine;

public class simpleLerp : MonoBehaviour {
    public Transform endT;
    public Transform startT;
    public float duration;

    [Range(0,1)]
    public float fraction;
    public bool useTime;
    public bool resetTime;

    float currTime;

    protected void Start() {
        currTime = 0;
	}

	protected void Update() {
        if (resetTime)
        {
            currTime = 0;
            resetTime = false;
        }

        if (useTime) {
            if (currTime > duration)
                return;
            fraction = currTime / duration;
            currTime += Time.deltaTime;
        }

        Debug.Log(fraction);
        transform.position = Vector3.Lerp(startT.position, endT.position, fraction);
        transform.rotation = Quaternion.Lerp(startT.rotation, endT.rotation, fraction);
        transform.localScale = Vector3.Lerp(startT.localScale, endT.localScale, fraction);
    }
}