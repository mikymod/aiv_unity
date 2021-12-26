using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandlerStart : MonoBehaviour, IPointerEnterHandler, IDragHandler, IPointerExitHandler
{
	public float pointerEnterScale 	= 2.0f;
	public float pointerExitScale 	= 1.0f;
    Canvas canvas;
    RectTransform rt;
    Camera cam;
    Vector3 posOnRect;

    private void Start()
    {
        rt = GetComponentInParent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        cam = Camera.main;
    }

    public void OnPointerEnter (PointerEventData eventData){
	}
	public void OnDrag (PointerEventData eventData){
    }
	public void OnPointerExit (PointerEventData eventData){
	}

}
