using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTester : MonoBehaviour
{
    public GameObject ObjToActivate;

    public void SwitcObjActiveState()
    {
        ObjToActivate.SetActive(!ObjToActivate.activeSelf);
    }

    public void PrintAnimEvent(AnimationEvent animEvent)
    {
        Debug.Log("float: "+ animEvent.floatParameter+
            "/ int: " + animEvent.intParameter+
            "/ string: " + animEvent.stringParameter+
            "/ obj: " + animEvent.objectReferenceParameter);
    }

    public void PrintFloat(float theValue)
    {
        Debug.Log("PrintFloat is called with a value of " + theValue);
    }

}
