using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemInfo : MonoBehaviour
{
    PointerEventData pointerEventData;
    //(pointer id -1,-2,-3 are left/right/center mouse buttons)
    public int PointerId = -1;
    string log;
    private void Update()
    {
        if(EventSystem.current == null)
        {
            Debug.Log("EventSystem.current is NULL");
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            log = ExtendedStandaloneInputModule.GetPointerEventData(PointerId).ToString();
        }

    }
    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical("box");
        GUILayout.Label(log);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
