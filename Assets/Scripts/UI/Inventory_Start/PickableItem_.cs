using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PickableItem_ : MonoBehaviour
{
    public Item_ item;
    public TMP_Text text;

    private int count = 0;

    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        text.text = count.ToString();
    } 

    private void Update()
    {
        text.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
    }
}
