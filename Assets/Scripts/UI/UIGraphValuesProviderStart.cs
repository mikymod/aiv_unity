using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UIGraphValuesProviderStart : MonoBehaviour
{
    public UIGraphStart UIGraphStartObj;
    
    public bool UpdateValues;
    private List<float> Values = new List<float>();

    public int numSteps = 100;
    private int stepsCount = 0;

    public float updateTime = 1f;
    private float updateTimer = 0;

    void Update()
    {
        if (stepsCount > numSteps)
        {
            return;
        }

        updateTimer += Time.deltaTime;
        UpdateValues = updateTimer > updateTime;

        if (UpdateValues)
        {
            updateTimer = 0f;
            UpdateValues = false;

            Values.Add(PopulateMeshPerson.sickValue);
            UIGraphStartObj.UpdateGraphValues(Values.ToArray());

            stepsCount++;
        }
    }
}
