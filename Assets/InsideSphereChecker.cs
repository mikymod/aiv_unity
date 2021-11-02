using UnityEngine;

public class InsideSphereChecker : MonoBehaviour
{
    private Transform timeBubble;
    private float radius;
    private AutoTranslate autoTranslate;
    private Vector3 initialSpeed;
    private Vector3 currentSpeed;

    void Start()
    {
        timeBubble = GameObject.FindGameObjectWithTag("Time Bubble").transform;
        radius = timeBubble.localScale.x / 2f;
        autoTranslate = GetComponent<AutoTranslate>();
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, timeBubble.position);
        if (distance < radius)
        {
            autoTranslate.ScaleMove();
        }
        else
        {
            autoTranslate.RestoreMove();
        }
    }
}
