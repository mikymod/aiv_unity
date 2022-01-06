using System;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    private Material material;

    private void OnEnable()
    {
        ColorManager.ClearGrid += ClearGridCallback;    
    }

    private void OnDisable()
    {
        ColorManager.ClearGrid -= ClearGridCallback;    
    }


    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;    
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = ColorManager.color;
                }
            }
        }
    }

    private void ClearGridCallback()
    {
        material.color = Color.white;
    }
}
