using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class DropDownListTest: MonoBehaviour
{
	//Create a List of new Dropdown options
	List<string> dropOptions = new List<string> { "Option 1", "Option 2"};
	//This is the Dropdown
	public TMP_Dropdown dropdown;

	[Serializable] public class StringEvent : UnityEvent <string> {}
	public StringEvent strEvent;

	void Start()
	{
		//Clear the old options of the Dropdown menu
		dropdown.ClearOptions();
		//Add the options created in the List above
		dropdown.AddOptions(dropOptions);
	}

    public void OnDropDownValueChanged(int newVal)
    {
        Debug.Log("DropDown new Value: "+newVal);
    }

	public void OnDio(string madonna)
	{

	}
}
