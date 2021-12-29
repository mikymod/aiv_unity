using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UICreator_Start : MonoBehaviour {
	///
	public static UICreator_Start instance;

	Canvas newCanvas;
	public string spriteResourcePath = "sprite";
    private GameObject canvas;

    private void Awake()
    {
        ///
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start () {
        //Create a new Canvas with its standard components
        CreateCanvas();
        //Create a new EventSystem
        CreateEventSystem();
        //Create a Sprite and Align it
		CreateSprite(new Vector2(0,0), spriteResourcePath, canvas.transform);
	}

    private void CreateCanvas()
    {
        canvas = new GameObject("Canvas");
        canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
    }

    private void CreateEventSystem()
    {
        GameObject go = new GameObject("EventSystem");
        go.AddComponent<EventSystem>();
        go.AddComponent<StandaloneInputModule>();
    }

    //Create a Sprite and Align it
    public GameObject CreateSprite(Vector2 pos, string resourcePath, Transform parent)
    {
        // - Create an Empty Game Object spriteGO
        GameObject spriteGO = new GameObject();
        spriteGO.transform.parent = parent;
        // - Create a New Sprite and load it from Resources folder
        Sprite sprite = Resources.Load<Sprite>(spriteResourcePath);
        // - Add an Image Component to the new spriteGO and set its sprite
        Image image = spriteGO.AddComponent<Image>();
        image.sprite = sprite;
       
        //- Move spriteGO using pos as a relative position
        RectTransform rectT = spriteGO.GetComponent<RectTransform>();
        rectT.anchoredPosition = pos;

        //- Set spriteGO position relative to parent edges (TOP LEFT)
        //If we don't specify the newSprite Size, it will be be 100x100 by default
        //Set the pos 50 units from the left parent edge and with width same as its original width
        //Eg. : rt.SetInsetAndSizeFromParentEdge (RectTransform.Edge.Left, distanceFromLeft, horizontalSize);
        rectT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 50f, sprite.rect.width);
        rectT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 50f, sprite.rect.height);

        //- Add interaction 
        spriteGO.AddComponent<SpriteEvents_Start>().Creator = this;

        return spriteGO;
    }
}
