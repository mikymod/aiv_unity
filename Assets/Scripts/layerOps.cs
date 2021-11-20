using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Perform a raycast using a combination of the two masks layerMaskA, layerMaskB
//If you want to invert the mask, just set invertMask to true
public class layerOps : MonoBehaviour {
    public int LayerNumA, LayerNumB;
	public string layerName;
	public float maxDistance = 10;
	public bool invertMask;
	int layerMaskA, layerMaskB, layerMask_AandB, invLayerMask_Aand;

    void UpdateLayerMask()
    {
        //from layer number to layer name
        Debug.Log("layerNumA layer name is " + LayerMask.LayerToName(LayerNumA));
        Debug.Log("layerNumB layer name is " + LayerMask.LayerToName(LayerNumB));

        //from to layer name to layer number
        Debug.Log("layer number of layer '" + layerName +"' is "+ LayerMask.NameToLayer(layerName));

        //Build a layermask via bitshift operator
        layerMaskA = 1 << LayerNumA;
        layerMaskB = 1 << LayerNumB;

        //Combine more layermasks
        layerMask_AandB = layerMaskA | layerMaskB;

        //Inverted layermask
        invLayerMask_Aand = ~layerMask_AandB;
    }

	void Update(){
        UpdateLayerMask();

        Ray customRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(customRay.origin, customRay.direction * maxDistance, Color.yellow);
		RaycastHit hitInfo;

		int currMask = invertMask ? invLayerMask_Aand : layerMask_AandB;
		if (Physics.Raycast (customRay, out hitInfo, maxDistance, currMask)) {
			Debug.Log ("Something is hitted at " + hitInfo.point + ", with layer " +
				LayerMask.LayerToName(hitInfo.collider.gameObject.layer));
		} else
			Debug.Log ("Raycast didn't hit anything");
	}
}
