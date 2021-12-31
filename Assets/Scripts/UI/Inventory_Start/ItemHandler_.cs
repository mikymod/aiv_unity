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
        EventMng_.ItemRemoved.AddListener(OnItemRemovedCallback);
    }
    
    //TODO UnSubscribe to events
    private void OnDisable()
    {
        EventMng_.ItemRemoved.RemoveListener(OnItemRemovedCallback);
    }

    //OnItemRemovedCallback
    //  - Istantiate the Item we want to remove with position near the player and itemsOnStageRootT as parent
    public void OnItemRemovedCallback(Item_ item, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var offset = Random.onUnitSphere;
            var go = Instantiate(
                Resources.Load<GameObject>(item.objPath),
                transform.position + new Vector3(offset.x + 1f, 1, offset.z + 1f),
                Quaternion.identity,
                itemsOnStageRootT
            );

            go.GetComponentInChildren<PickableItem_>().quantity = 1;
            go.GetComponentInChildren<Animator>().SetTrigger("Spawn");
        }        
    }

    //React to collision enter
    //  - Take PickableItem component from the collider gameObject 
    //  - Trigger EventMng.instance.OnItemPicked (what parameters do you have to pass?)
    private void OnCollisionEnter(Collision other)
    {
        var pickableComp = other.gameObject.GetComponent<PickableItem_>();
        if (pickableComp != null)
        {
            EventMng_.ItemPicked.Invoke(pickableComp.item, other.gameObject, pickableComp.quantity);
        }
    }
}
