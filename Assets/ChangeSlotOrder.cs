using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSlotOrder : MonoBehaviour
{
    private RectTransform rootPanel;
    private RectTransform rt;
    private LayoutElement element;
    private GameObject transparentImage;
    private Vector3 offset;

    private void Start()
    {
        rootPanel = transform.parent.GetComponent<RectTransform>();
        rt = GetComponent<RectTransform>();
        element = GetComponent<LayoutElement>();
    }

    public void OnPointerDown() 
    {
        transparentImage = Instantiate(gameObject, transform.parent);
        transparentImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        transparentImage.transform.SetSiblingIndex(transform.GetSiblingIndex());
        element.ignoreLayout = true;

        offset = Input.mousePosition - rt.position;
    }

    public void OnDrag() 
    {
        rt.position = Input.mousePosition - offset;
    }

    private int FindSiblingIndex()
    {
        float parentWidth = rootPanel.sizeDelta.x;
        int numChildren = transform.parent.childCount;
        float childWidth = parentWidth / (float) numChildren;
        return (int)(rt.anchoredPosition.x / childWidth);
    }

    public void OnPointerUp() 
    {
        transform.SetSiblingIndex(FindSiblingIndex());
        element.ignoreLayout = false;
        Destroy(transparentImage);
    }
}
