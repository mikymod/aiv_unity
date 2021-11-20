using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTime : MonoBehaviour
{
    float time, lastTime, timeCounterUntilOne;
    int updateCounter, fixedUpdateCounter;
    float updatePerSecond, fixedUpdatePerSecond;
    bool resetFixed;
    // Start is called before the first frame update
    void Start()
    {
        timeCounterUntilOne = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounterUntilOne += Time.deltaTime;
        if(timeCounterUntilOne > 1) {
            timeCounterUntilOne = 0;
            updatePerSecond = updateCounter;
            fixedUpdatePerSecond = fixedUpdateCounter;
            updateCounter = 0;
            fixedUpdateCounter = 0;
        }
        updateCounter++;
        Debug.Log("Update realTime: " + Time.realtimeSinceStartup);
    }
    void FixedUpdate()
    {
        fixedUpdateCounter++;
        Debug.Log("FixedUpdate realTime: " + Time.realtimeSinceStartup);
    }

    void OnGUI()
    {
        GUILayout.BeginVertical("box");
        GUILayout.Label("Unity is calling\nUPDATE " + updatePerSecond + " times/s\nFIXED UPDATE " + fixedUpdatePerSecond + " times/s");
        GUILayout.EndVertical();
    }
}
