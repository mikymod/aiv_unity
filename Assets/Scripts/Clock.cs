using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private Transform seconds;
    [SerializeField] private Transform minutes;
    [SerializeField] private Transform hours;

    void Update()
    { 
        seconds.Rotate(new Vector3(0, (360f / 60f) * Time.deltaTime, 0));
        minutes.Rotate(new Vector3(0, (360f / (60f * 60f))  * Time.deltaTime, 0));
        hours.Rotate(new Vector3(0, (360f / (60f * 60f * 12))  * Time.deltaTime, 0));
    }
}
