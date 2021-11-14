using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    int points;
    int IMGUIx, IMGUIy;
    int IMGUIh = 20;

    private void OnEnable()
    {
        Collectable.OnPickUp += AddPoint;    
    }

    private void OnDisable()
    {
        Collectable.OnPickUp -= AddPoint;    
    }

    public void AddPoint(int val)
    {
        points += val;
    }

    void OnGUI()
    {
        IMGUIx = IMGUIy = 10;

        // Make a background box
        GUI.Box(new Rect(IMGUIx, IMGUIy, 50, 50), "Points");
        IMGUIx += 5;
        IMGUIy += 20;
        GUI.Label(new Rect(IMGUIx, IMGUIy, 100, IMGUIh), points.ToString());
    }
}
