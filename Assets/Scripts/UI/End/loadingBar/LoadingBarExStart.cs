using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingBarExStart : MonoBehaviour {
	public Image loadingBar; 	//Filled img
	public Text feedbackText;	
	public Text loadValText;	//Load percentage value
	public Image overlayPanel;	//Full screen img

	float fillVal;		//Loading bar fill
	float overlayAlpha;	//white panel in overlay

	//Increment values (Loading bar, overlay white panel alpha fade in)
	public float loadingIncVal;
	public float alphaIncVal;

	//feedbackText == startText at the beginning, endText after loading == 100
	public string startText;
	public string endText;

	void Start(){
	}

	void Update () {
	}
}
