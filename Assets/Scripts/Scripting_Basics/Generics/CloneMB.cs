using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMB : MonoBehaviour
{
    void Start()
    {
        ClonableClass originalClass = new ClonableClass();
        originalClass.life = 100;
        originalClass.power = 200;
        originalClass.name = "className";
        ClonableClass clonedClass = originalClass.Clone();
        Debug.Log("clonedClass - life: "+ clonedClass.life + " power: " + clonedClass.power + " clonedClass.name: " + clonedClass.name);
    }
}
