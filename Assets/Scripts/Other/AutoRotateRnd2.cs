using UnityEngine;

public class AutoRotateRnd2 : MonoBehaviour
{
	public Vector3 minRot;
	public Vector3 maxRot;

	public Vector3 currRot;

    private void Start()
    {
		currRot = new Vector3(Random.Range(minRot.x, maxRot.x), Random.Range(minRot.y, maxRot.y), Random.Range(minRot.z, maxRot.z));
    }


    private void FixedUpdate()
    {
        float deltaTime = Time.deltaTime;
		transform.Rotate(currRot*deltaTime, Space.Self);
    }
}
