using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericsMB : MonoBehaviour
{
    private void Start()
    {
        Generics g = new Generics();
        Transform t = g.GMethodWithReferenceType<Transform>(transform);
        int valt = g.GMethodWithValueType<int>(5);
        ClassA classA = g.GMethodWithSpecificClass<ClassA>(new ClassA());
        PointStruct ps = g.GMethodWithSpecificInterface<PointStruct>(new PointStruct());
        ClassA classA2 = g.GMethodWithDefaultContructor<ClassA>(new ClassA());
        
        //This is an error
        //classWithoutDefaultContructor c = g.GMethodWithDefaultContructor<classWithoutDefaultContructor>(new classWithoutDefaultContructor());
        ClassA classA3 = g.GMethodWithReferenceTypeAndValueType<ClassA, int>(new ClassA(), 5);
    }
}
