using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonExStart : MonoBehaviour {
	public Color HighlightCol;
	public Color NormalCol;
	public Color PressedCol;
	public Color DisabledCol;
	public bool active;
	public Image img;           //Image of the fake button that will behave like the real button

	bool currState;
    private bool highlighted = false;

    private void Update()
	{
		if (!active)
		{
			img.color = DisabledCol;
			return;
		}
		

		if (!isSelected() && !highlighted)
		{
			img.color = NormalCol;
		}
	}
	
	bool isSelected () => EventSystem.current.currentSelectedGameObject == img.gameObject;

	public void OnEnter()
	{
		if (!active)
			return;
		img.color = HighlightCol;
		highlighted = true;
	}

	public void OnExit()
	{
		if (!active)
			return;

		highlighted = false;

		if (isSelected())
		{
			img.color = HighlightCol;
		}
		else
		{
			img.color = NormalCol;
		}		
	}
	
	public void OnPointerDown()
	{
		if (!active)
			return;
		img.color = PressedCol;
		EventSystem.current.SetSelectedGameObject(img.gameObject);
		currState = true;
	}

	public void OnPointerUp()
	{
		if (!active)
			return;
		img.color = HighlightCol;

		// EventSystem.current.SetSelectedGameObject(img.gameObject);
	}
}
