using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Transform[] orientations;
    [SerializeField] private AnimationCurve curve;
    private Transform currentOrientation;

    private void Start()
    {
        currentOrientation = orientations[0];
        transform.position = currentOrientation.transform.position;
        transform.rotation = currentOrientation.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            currentOrientation = orientations[0];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            currentOrientation = orientations[1];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            currentOrientation = orientations[2];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            currentOrientation = orientations[3];
        }

        transform.position = Vector3.Lerp(transform.position, currentOrientation.position, curve.Evaluate(Time.deltaTime));
        var transformEuler = transform.rotation.eulerAngles;
        var orientationEuler = currentOrientation.rotation.eulerAngles;
        transformEuler = Vector3.Slerp(transformEuler, orientationEuler, curve.Evaluate(Time.deltaTime));
        transform.rotation = Quaternion.Euler(transformEuler);
    }
}
