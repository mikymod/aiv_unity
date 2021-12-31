using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

/*
 * Trigger this event
 * -EventMng.instance.OnItemRemoved
 */
public class CellItem_ : MonoBehaviour, IPointerClickHandler
{
    //public Item field to have a reference for the Item contained in this cell
    public Item_ ItemInThisCell;
    private Image image;
    private TMP_Text text;

    public static UnityEvent<Item_, GameObject> CellItemUpdate = new UnityEvent<Item_, GameObject>(); 

    private int count = 0;
    public int Count { get => count; }

    private void Start()
    {
        enabled = false;
        
        image = GetComponent<Image>();
        text = GetComponentInChildren<TMP_Text>();
        text.text = count.ToString();
    }

    public void SetSprite(Sprite sprite)
    {
        this.image.sprite = sprite;        
    }

    public void SetCount(int count)
    {
        this.count = count;
        text.text = this.count.ToString();
    }

    public void IncreaseCount(int quantity)
    {
        count += quantity;
        text.text = count.ToString();
    }

    public void DecreaseCount()
    {
        count--;
        text.text = count.ToString();
    }

    public void RemoveMyself(bool removeAll)
    {
        EventMng_.ItemRemoved.Invoke(ItemInThisCell, removeAll ? count : 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RemoveMyself(eventData.button == PointerEventData.InputButton.Right ? true : false);
    }
}
