using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  BUTTON NAMES
 *  Normal keys: “a”, “b”, “c” …
    Number keys: “1”, “2”, “3”, …
    Arrow keys: “up”, “down”, “left”, “right”
    Keypad keys: “[1]”, “[2]”, “[3]”, “[+]”, “[equals]”
    Modifier keys: “right shift”, “left shift”, “right ctrl”, “left ctrl”, “right alt”, “left alt”, “right cmd”, “left cmd”
    Mouse Buttons: “mouse 0”, “mouse 1”, “mouse 2”, …
    Joystick Buttons (from any joysticKCode: “joystick button 0”, “joystick button 1”, “joystick button 2”, …
    Joystick Buttons (from a specific joysticKCode: “joystick 1 button 0”, “joystick 1 button 1”, “joystick 2 button 0”, …
    Special keys: “backspace”, “tab”, “return”, “escape”, “space”, “delete”, “enter”, “insert”, “home”, “end”, “page up”, “page down”
    Function keys: “f1”, “f2”, “f3”, …
 */
public class InputTest : MonoBehaviour
{
    public KeyCode KCode;
    public float XOffset;
    public Transform ObjToMove;
    public string buttonName = "Horizontal";
    Vector3 startPos = Vector3.zero;

    private void Start()
    {
        startPos = ObjToMove.position;
    }

    void Update()
    {
        if (Input.GetKey(KCode))
            Debug.Log("GetKey");
        if (Input.GetKeyDown(KCode))
            Debug.Log("GetKeyDown");
        if (Input.GetKeyUp(KCode))
            Debug.Log("GetKeyUp");
        if (Input.GetButton(buttonName))
            Debug.Log("GetButton");
        if (Input.GetButtonDown(buttonName))
            Debug.Log("GetButtonDown");
        if (Input.GetButtonUp(buttonName))
            Debug.Log("GetButtonUp");

        //Try to change Gravity/Sensitivity of this axis
        Debug.Log(Input.GetAxis(buttonName));

        ObjToMove.position = startPos + new Vector3(Input.GetAxis(buttonName), 0, 0);
    }
}
