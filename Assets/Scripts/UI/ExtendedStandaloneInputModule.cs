using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ExtendedStandaloneInputModule : StandaloneInputModule
{
    private static ExtendedStandaloneInputModule _instance;
    public bool IsMouseInputActive = true;
    public bool IsKeyboardInputActive = true;
    public bool IsMouseVisible = true;
    public CursorLockMode CurrCursorLockMode;
    public bool UseCustomCursor;
    public Texture2D CursorTexture;
    public Vector2 CursorHotspot = new Vector2(128,0); //0,0 is Top-Left
    protected override void Awake()
    {
        base.Awake();
        _instance = this;
    }

    //Useful to know Pointer event data infos
    public static PointerEventData GetPointerEventData(int pointerId = -1)
    {
        PointerEventData eventData;
        _instance.GetPointerData(pointerId, out eventData, true);
        return eventData;
    }

    //inherited event processing interface (called every frame)
    public override void Process()
    {
        bool usedEvent = SendUpdateEventToSelectedObject();

        eventSystem.sendNavigationEvents = IsKeyboardInputActive;
        if (eventSystem.sendNavigationEvents)
        {
            if (!usedEvent)
                //Calculate and send a move event to the current selected object
                //  true If the move event was used by the selected object
                usedEvent |= SendMoveEventToSelectedObject();
            if (!usedEvent)
                //If previously move event was not used, calculate and send a submit
                //  event to the current selected object
                //  true If the submit event was used by the selected object
                SendSubmitEventToSelectedObject();
        }

        if (IsMouseInputActive)
            //Iterate through all the different mouse events
            ProcessMouseEvent();

        Cursor.lockState = CurrCursorLockMode;//Confined: Confine cursor to the gameWindow
        Cursor.visible = IsMouseVisible;
        if (UseCustomCursor)
            Cursor.SetCursor(CursorTexture, CursorHotspot, CursorMode.Auto);
    }
}