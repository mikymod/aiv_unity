using UnityEngine;
using UnityEngine.Events;

public class PickColor : MonoBehaviour
{
    public static UnityAction<Color> ColorPicked;

    private void OnMouseDown()
    {
        var color = GetComponent<MeshRenderer>().material.color;
        ColorPicked?.Invoke(color);
    }
}
