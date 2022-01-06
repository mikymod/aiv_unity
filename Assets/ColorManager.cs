using UnityEngine;
using UnityEngine.Events;

public class ColorManager : MonoBehaviour
{
    public static Color color;
    public MeshRenderer pickedColor;

    public static UnityAction ClearGrid;

    private void OnEnable()
    {
        PickColor.ColorPicked += ColorPickedCallback;
    }

    private void OnDisable()
    {
        PickColor.ColorPicked -= ColorPickedCallback;
    }

    private void ColorPickedCallback(Color col)
    {
        color = col;
        pickedColor.material.color = col;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ClearGrid?.Invoke();
        }    
    }
}
