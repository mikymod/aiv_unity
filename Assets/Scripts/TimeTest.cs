using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    float time, deltaTime, realtimeSinceStartup, timeScale, unscaledDeltaTime, unscaledTime;
    float timeScaleSetter = 1;
    int IMGUIx, IMGUIy, IMGUIh = 25;
    bool paused = false;

    void newLine()
    {
        IMGUIy += IMGUIh;
    }

    void Update()
    {
        time = Time.time;
        deltaTime = Time.deltaTime;
        realtimeSinceStartup = Time.realtimeSinceStartup;
        timeScale = Time.timeScale;
        if (Mathf.Abs(timeScale - timeScaleSetter) > 0.01)
            Time.timeScale = timeScaleSetter;

        unscaledDeltaTime = Time.unscaledDeltaTime;
        unscaledTime = Time.unscaledTime;
    }

    void OnGUI()
    {
        IMGUIx = IMGUIy = 10;

        // Make a background box
        GUI.Box(new Rect(IMGUIx, IMGUIy, 300, 400), "IMGUI Test"); newLine();
        IMGUIx += 5;

        paused = GUI.Toggle(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), paused, "PAUSE"); newLine();
        if (paused) 
            Time.timeScale = timeScaleSetter = 0;

        timeScaleSetter = GUI.HorizontalSlider(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), timeScaleSetter, 0.0f, 1.0f); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "timeScale " + timeScale.ToString("0.00")); newLine();

        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "time " + time.ToString("0.00")); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "deltaTime " + deltaTime.ToString("0.00")); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "realtimeSinceStartup " + realtimeSinceStartup.ToString("0.00")); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "timeScale " + timeScale.ToString("0.00")); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "unscaledDeltaTime " + unscaledDeltaTime.ToString("0.00")); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "unscaledTime " + unscaledTime.ToString("0.00")); newLine();
    }
}
