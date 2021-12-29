using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Implement BeginDrag, Drag, EndDrag
public class SpriteEvents_Start : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Vector3 startPos;
	GameObject dragGO;

        public UICreator_Start Creator;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Save start position startPos
        startPos = gameObject.transform.position;
        //Create a new sprite dragGO (Use UICreator_ for it) at startPos
        dragGO = Creator.CreateSprite(startPos, Creator.spriteResourcePath, gameObject.transform.parent);
        //Set the Image color alpha on This GO to 0.5f
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        //dragGO should move along with the mouse
        dragGO.transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData){
        //If SpaceBar is not pressed
        //  - move This GO where dragGO is
        //  - destroy dragGO
        //Else
        //  - Set the Image color alpha on This GO to 1.0f
        if (!Input.GetKey(KeyCode.Space))
        {
            transform.position = dragGO.transform.position;
            Destroy(dragGO);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f); 
        }
	}
}
