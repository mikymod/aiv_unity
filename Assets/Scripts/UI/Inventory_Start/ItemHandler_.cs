using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Listen to this event:
 * -EventMng.instance.OnItemRemoved (OnItemRemovedCallback)
 * Triggers this event:
 * -EventMng.instance.OnItemPicked
 */
public class ItemHandler_ : MonoBehaviour {
    public Transform itemsOnStageRootT; //parent of items on stage. Add here 3D items removed from Inventory

    //TODO Subscribe to events
    private void OnEnable()
    {
    }
    //TODO UnSubscribe to events
    private void OnDisable()
    {
    }

    //OnItemRemovedCallback
    //  - Istantiate the Item we want to remove with position near the player and itemsOnStageRootT as parent

    //React to collision enter
    //  - Take PickableItem component from the collider gameObject 
    //  - Trigger EventMng.instance.OnItemPicked (what parameters do you have to pass?)
}
