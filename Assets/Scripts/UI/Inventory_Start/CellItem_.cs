using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * Trigger this event
 * -EventMng.instance.OnItemRemoved
 */
public class CellItem_ : MonoBehaviour, IPointerClickHandler
{
    //public Item field to have a reference for the Item contained in this cell
    public Item_ ItemInThisCell;
    private Image image;

    private void Start()
    {
        enabled = false;
        
        image = GetComponent<Image>();
    }

    public void SetSprite(Sprite sprite)
    {
        this.image.sprite = sprite;
    }

    public void RemoveMyself()
    {
        EventMng_.ItemRemoved.Invoke(ItemInThisCell);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RemoveMyself();
    }
}
