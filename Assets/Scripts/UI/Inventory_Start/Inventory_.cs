using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

/*
 * Listen to these events:
 * -EventMng.instance.OnItemPicked (OnAddItemCallback)
 * -EventMng.instance.OnItemRemoved (OnItemRemovedCallback)
 */
public class Inventory_ : MonoBehaviour {
	public int inventorySize = 3;
	public GameObject cellItemPrefab;
	private int itemsCollected = 0;
    private List<CellItem_> cellItems;

    private Dictionary<Item_, int> itemsCount;

    private void Awake()
    {
        cellItems = new List<CellItem_>(inventorySize);
        itemsCount = new Dictionary<Item_, int>();
    }

    private void Start()
    {
        //- Istantiate cellItemPrefab inventorySize times, taking this as the root parent
        for (int i = 0; i < inventorySize; i++)
        {
            var go = Instantiate(cellItemPrefab, transform);
            var cellItem = go.GetComponentInChildren<CellItem_>();

            //- Initialize each CellItem.ItemInThisCell to null
            cellItem.ItemInThisCell = null;
            cellItems.Add(cellItem);
        }
    }

    private void OnEnable()
    {
        //- Subscribe to events
        EventMng_.ItemPicked.AddListener(OnItemPickedCallback);
        EventMng_.ItemRemoved.AddListener(OnItemRemovedCallback);
    }

    //TODO UnSubscribe to events
    private void OnDisable()
    {
        EventMng_.ItemPicked.RemoveListener(OnItemPickedCallback);
        EventMng_.ItemRemoved.RemoveListener(OnItemRemovedCallback);
    }

    /*
     * OnAddItemCallback
     * - check if canGrabItem()
     * - check if we already have that item in the inventory AND if not,
     *      take the reference of the first empty cell
     * - If we don't have that item, assign the new Item sprite icon to the
     *      fgImage of the found empty cell
     *      - enable the fgImage
     *      - Update CellItem.ItemInThisCell with the Item we want to add
     *      - itemsCollected++;
     *      - Destroy 3D Game object on the stage floor
     * - else return;  
     * */
    private void OnItemPickedCallback(Item_ item, GameObject go)
    {
        if (!CanGrabItem())
        {
            return;
        }

        if (!cellItems.Any<CellItem_>((i) => i.ItemInThisCell != null && i.ItemInThisCell.Equals(item)))
        {
            var firstCellItem = cellItems.First<CellItem_>((i) => i.ItemInThisCell == null);
            firstCellItem.enabled = true;
            firstCellItem.ItemInThisCell = item;

            var image = Resources.Load<Sprite>(item.spritePath);
            firstCellItem.SetSprite(image);
            firstCellItem.SetCount(1);

            itemsCollected++;
        }
        else
        {
            var cellItem = cellItems.First<CellItem_>((i) => i.ItemInThisCell.Equals(item));
            if (cellItem)
            {
                cellItem.IncreaseCount();
            }
        }

        Destroy(go.transform.parent.gameObject);
    }

    /*
     * OnItemRemovedCallback
     * - Find the inventory cell with the Item we want to remove
     * - Set CellItem fgImage component to disable
     * - Set CellItem.ItemInThisCell to null
     * - itemsCollected--;
     * */
    private void OnItemRemovedCallback(Item_ item)
    {
        CellItem_ cellItem = cellItems.First<CellItem_>((i) => i.ItemInThisCell == item);
        if (cellItem)
        {
            if (cellItem.Count == 1)
            {
                cellItem.enabled = false;
                cellItem.ItemInThisCell = null;
                cellItem.SetSprite(null);
            }

            cellItem.DecreaseCount();
            
            itemsCollected--;
        }
    }

    bool CanGrabItem()
    {
		return itemsCollected < inventorySize;
	}

    bool ItemAlreadyPresent(Item_ item)
    {
        return cellItems.Any<CellItem_>((i) => i.ItemInThisCell.Equals(item));
    }
}
