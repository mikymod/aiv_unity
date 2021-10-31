using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI2 : MonoBehaviour
{
    private bool toggleBool = true;
    private int toolbarInt = 0;
    private string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };
    private float hSliderValue = 0.0f;
    private float vSliderValue = 0.0f;
    public GUIStyle CustomLabel;
    public GUISkin CustomSkin;
    public int GroupX = 10, GroupY = 300;
    public int AreaX = 10, AreaY = 10;

    int IMGUIx, IMGUIy, IMGUIh = 25;
    float sliderValue = 1.0f;
    float maxSliderValue = 10.0f;
    void newLine() => IMGUIy += IMGUIh;

    void OnGUI()
    {
        if(CustomSkin != null)
            GUI.skin = CustomSkin;

        IMGUIx = Screen.width / 2;
        IMGUIy = 10;

        //---FIXED LAYOUT
        // Make a background box
        GUI.Box(new Rect(IMGUIx, IMGUIy, 300, 400), "IMGUI Test"); newLine();
        IMGUIx += 5;
        GUI.Label(new Rect(IMGUIx, IMGUIy, 100, IMGUIh), "Label", CustomLabel); newLine();
        if (GUI.Button(new Rect(IMGUIx, IMGUIy, 100, IMGUIh), "Button")) 
        {
            // This code is executed when the Button is clicked
            Debug.Log("Button pressed");
        }
        newLine();

        toggleBool = GUI.Toggle(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), toggleBool, "Toggle"); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "toggleBool "+ toggleBool); newLine();

        toolbarInt = GUI.Toolbar(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), toolbarInt, toolbarStrings); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "toolbarInt " + toolbarInt); newLine();

        hSliderValue = GUI.HorizontalSlider(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), hSliderValue, 0.0f, 10.0f); newLine();
        GUI.Label(new Rect(IMGUIx, IMGUIy, 200, IMGUIh), "hSliderValue " + hSliderValue.ToString(".00")); newLine();

        vSliderValue = GUI.VerticalSlider(new Rect(IMGUIx, IMGUIy, 200, IMGUIh*5), vSliderValue, 10.0f, 0.0f); newLine();
        GUI.Label(new Rect(IMGUIx*2, IMGUIy, 200, IMGUIh), "vSliderValue " + vSliderValue.ToString(".00")); newLine();

        // Make a group
        GUI.BeginGroup(new Rect(GroupX, GroupY, 100, 100));
            // We'll make a box so you can see where the group is on-screen.
            GUI.Box(new Rect(0, 0, 100, 100), "Group is here");
            GUI.Button(new Rect(10, 40, 80, 30), "Click me");
        GUI.EndGroup();

        //---AUTOMATIC LAYOUT
        // Wrap everything in the designated GUI Area
        GUILayout.BeginArea(new Rect(AreaX, AreaY, 300, 160));
        // Begin the singular Horizontal Group
        GUILayout.BeginHorizontal();
            GUILayout.Label("Auto Label1");
            GUILayout.Label("Auto Label2");

            // Place a Button normally
            if (GUILayout.RepeatButton("Increase max\nSlider Value"))
                maxSliderValue += 3.0f * Time.deltaTime;

            // Arrange more Controls vertically beside the Button
            GUILayout.BeginVertical();
                GUILayout.Box("Slider Value: " + Mathf.Round(sliderValue));
                sliderValue = GUILayout.HorizontalSlider(sliderValue, 0.0f, maxSliderValue);
                GUILayout.Label("Auto Label3");
            // End the Groups and Area
            GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
