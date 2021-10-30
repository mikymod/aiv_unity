using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
    public static void ResetTranslation(this Transform t)
    {
        t.position = Vector3.zero;
    }
}
