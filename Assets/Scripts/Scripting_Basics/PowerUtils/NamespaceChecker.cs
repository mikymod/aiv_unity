using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerUtils;
//using NormalUtils;

public class NamespaceChecker : MonoBehaviour
{
    void Start()
    {
        Utils utils = new Utils();
        int intResult = utils.Add(1, 2);

        Vector2 v2Result = utils.Add(new Vector2(1, 1), new Vector2(2, 2));
        Debug.Log("intResult: " + intResult);
        Debug.Log("v2Result: " + v2Result);
    }
}
