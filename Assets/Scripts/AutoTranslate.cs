using UnityEngine;

public class AutoTranslate: MonoBehaviour
{
	public bool performUpdate;
	public Vector3 move;
	public float scaleFactor;
	public float rotSpeed = 50f;
	

	private Vector3 currentMove;
	private float currentRotSpeed;


	private void Start()
	{
		RestoreMove();
	}

	private void Update()
	{
		if (performUpdate)
		{
			transform.Translate(currentMove.x * Time.deltaTime, currentMove.y * Time.deltaTime, currentMove.z * Time.deltaTime);
			transform.Rotate(new Vector3(0, 0, currentRotSpeed * Time.deltaTime));
		}
	}

    public void ScaleMove()
	{
		currentMove = move * scaleFactor;
		currentRotSpeed = rotSpeed * scaleFactor;
	}

    public void RestoreMove() 
	{
		currentMove = move;
		currentRotSpeed = rotSpeed;
	}
}
