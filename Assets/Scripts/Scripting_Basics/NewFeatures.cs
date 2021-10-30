using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFeatures : MonoBehaviour
{
    public Transform ObjTransform;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        string name = "World";
        int power = 100;
        int propsNum = 3;

        // Composite formatting:
        Debug.LogFormat("Hello, {0}! Your power is {1}, you've got {2} props.", name, power, propsNum);
        // String interpolation:
        Debug.LogFormat($"Hello, {name}! Your power is {power}, you've got {propsNum} props.");

        //Null conditional
        ObjTransform?.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    void UpdateCounter()
    {
        counter = 0;
    }
    //Expression-Bodied members
    void UpdateCounter_EBM() => counter = 0;
}
