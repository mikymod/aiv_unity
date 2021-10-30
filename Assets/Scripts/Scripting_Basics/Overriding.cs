using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overriding : MonoBehaviour
{
    ClassA[] AClasses = new ClassA[10];

    void Start()
    {
        for (int i = 0; i < AClasses.Length; i++)
        {
            if (i < AClasses.Length / 2)
                AClasses[i] = new ClassA();
            else
                AClasses[i] = new ClassB();
        }

        for (int i = 0; i < AClasses.Length; i++)
        {
            AClasses[i].Fire2();
        }
    }
}
