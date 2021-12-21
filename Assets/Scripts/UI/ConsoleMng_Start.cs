using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConsoleMng_Start : MonoBehaviour
{
    public TextMeshProUGUI TextConsole;
    public TMP_InputField InField;
    public Image Background;
    public ScrollRect ScrollView;
    public int maxTextLen = 512;
    bool isFocused = false;

    private void Start()
    {
        InField.Select();
        InField.ActivateInputField();        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isFocused)
        {
            SubmitCmd(InField.text);
        }
        isFocused = InField.isFocused;
    }

    public void OnValueChanged(string text)
    {
        Debug.Log("OnValueChanged Event: " + text);
    }
    public void OnEndEdit(string text)
    {
        Debug.Log("OnEndEdit Event: " + text);
    }
    public void OnSelect(string text)
    {
        Debug.Log("OnSelect Event: " + text);
    }
    public void OnDeselect(string text)
    {
        Debug.Log("OnDeselect Event: " + text);
    }

    public void SubmitCmd(string newCmd)
    {
        // Avoid empty command
        if (newCmd == "")
        {
            return;
        }

        // Autoclear
        if (TextConsole.text.Length > maxTextLen)
        {
            TextConsole.text = "";
        }

        TextConsole.text += "\n<color=white><b>" + newCmd + "</b>";
        InField.text = "";

        //Set again the focus on the InputField
        InField.Select();
        InField.ActivateInputField();

        //...
        newCmd = newCmd.ToLower();
        var splittedCmd = newCmd.Split(' ');
        switch(splittedCmd[0])
        {
            case "font":
                if (splittedCmd.Length == 2)
                {
                    if (int.TryParse(splittedCmd[1], out int size))
                    {
                        TextConsole.text += "\n<color=green><b>OK</b>";
                        TextConsole.fontSize = size;
                    }
                    else
                    {
                        TextConsole.text += "\n<color=red><b>Wrong parameter. Must be a number</b>";
                    }
                }
                else
                {
                    TextConsole.text += "\n<color=red><b>Wrong format. Usage: font num</b>";
                }
                break;
            case "background":
                if (splittedCmd.Length == 4)
                {
                    int.TryParse(splittedCmd[1], out int red);
                    int.TryParse(splittedCmd[2], out int green);
                    int.TryParse(splittedCmd[3], out int blue);
                    if ((red >= 0 && red < 256) && (green >= 0 && green < 256) && (blue >= 0 && blue < 256))
                    {
                        Background.color = new Color(Mathf.Clamp01(red), Mathf.Clamp01(green), Mathf.Clamp01(blue));
                        TextConsole.text += "\n<color=green><b>OK</b>";
                    }
                    else
                    {
                        TextConsole.text += "\n<color=red><b>Wrong parameters: 0 <= x <= 255</b>";
                    }
                }
                else
                {
                    TextConsole.text += "\n<color=red><b>Wrong format. Usage: background num num num</b>";
                }
                break;
            case "clear":
                TextConsole.text = "";
                break;
            default:
                TextConsole.text += "\n<color=red><b>Unknown command</b>";
                break;
        }

        // Scroll to bottom
        Canvas.ForceUpdateCanvases();
        ScrollView.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }
}
