using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// using System;

public class PickableItem_ : MonoBehaviour
{
    public Item_ item;
    public TMP_Text text;

    public int quantity;

    private void Awake()
    {
        quantity = Random.Range(1, 5); // TODO: avoid magic values
        text = transform.parent.GetComponentInChildren<TMP_Text>();
        text.text = quantity.ToString();
    }

    private void Update()
    {
        text.text = quantity.ToString();
        text.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
        text.transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
    }    
}
