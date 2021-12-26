using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*
 * Listen to these events:
 * -EventMng.instance.OnItemPicked (OnAddItemCallback)
 * -EventMng.instance.OnItemRemoved (OnItemRemovedCallback)
 */
public class Inventory_ : MonoBehaviour {
	public int inventorySize = 3;
	public GameObject cellItemPrefab;
	private int itemsCollected = 0;

    private void OnEnable()
    {
        //- Subscribe to events
        //- Istantiate cellItemPrefab inventorySize times, taking this as the root parent
        //- Initialize each CellItem.ItemInThisCell to null
    }
    //TODO UnSubscribe to events
    private void OnDisable()
    {
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

    /*
     * OnItemRemovedCallback
     * - Find the inventory cell with the Item we want to remove
     * - Set CellItem fgImage component to disable
     * - Set CellItem.ItemInThisCell to null
     * - itemsCollected--;
     * */

    bool canGrabItem(){
		return itemsCollected < inventorySize;
	}
}
