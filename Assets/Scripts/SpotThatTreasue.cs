using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotThatTreasue : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] private Slider HSlider;
    [SerializeField] private Slider VSlider;
    [SerializeField] private RectTransform mask;
    [SerializeField] private RectTransform treasureMapBlurred;
    [SerializeField] private RectTransform treasureMap;
    [SerializeField] private RectTransform treasure;

    [Header("Radar")]
    [SerializeField] private RectTransform radar;
    [SerializeField] private RectTransform radarTreasure;

    private Vector2 treasureMapForcedPos;
    private Vector3 treasureForcedPos;

    private void Start()
    {
        treasureMapForcedPos = treasureMap.position;
        treasureForcedPos = new Vector2(
            Random.Range(treasureMapBlurred.rect.xMin, treasureMapBlurred.rect.xMax - mask.sizeDelta.x),
            Random.Range(treasureMapBlurred.rect.yMin, treasureMapBlurred.rect.yMax - mask.sizeDelta.y)
        );
        radarTreasure.anchoredPosition = new Vector2(
            RemapExtMethod.Remap(
                treasureForcedPos.x,
                treasureMapBlurred.rect.xMin,
                treasureMapBlurred.rect.xMax - mask.sizeDelta.x,
                radar.rect.xMin,
                radar.rect.xMax - radarTreasure.sizeDelta.x
            ),
            RemapExtMethod.Remap(
                treasureForcedPos.y,
                treasureMapBlurred.rect.yMin,
                treasureMapBlurred.rect.yMax - mask.sizeDelta.y,
                radar.rect.yMin,
                radar.rect.yMax - radarTreasure.sizeDelta.y
            )
        );
    }

    private void Update()
    {
        treasureMap.position = treasureMapForcedPos;
        treasure.position = treasureForcedPos;

        var hValue = RemapExtMethod.Remap(HSlider.value, HSlider.minValue, HSlider.maxValue, treasureMapBlurred.rect.xMin, treasureMapBlurred.rect.xMax - mask.sizeDelta.x);
        var vValue = RemapExtMethod.Remap(VSlider.value, VSlider.minValue, VSlider.maxValue, treasureMapBlurred.rect.yMin, treasureMapBlurred.rect.yMax - mask.sizeDelta.y);
        mask.anchoredPosition = new Vector2(hValue, vValue);
    }
}
