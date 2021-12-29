using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UIGraphValuesProviderStart : MonoBehaviour
{
    public UIGraphStart UIGraphStartObj;
    public bool UpdateValues;
    public float[] Values;

    void Update()
    {
        if (UpdateValues)
        {
            UpdateValues = false;
            UIGraphStartObj.UpdateGraphValues(Values);
        }
    }
}
