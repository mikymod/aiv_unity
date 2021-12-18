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
    bool isFocused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isFocused)
            SubmitCmd(InField.text);
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
        TextConsole.text += "\n<b>" + newCmd + "</b>";
        InField.text = "";
        //Set again the focus on the InputField
        //...
    }
}
