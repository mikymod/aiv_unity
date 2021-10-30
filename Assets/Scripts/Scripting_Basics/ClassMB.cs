using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMB : MonoBehaviour
{
    void Start()
    {
        //0
        ClassA classA = new ClassA();
        ClassB classB = new ClassB();

        string result;
        result = classA.MethodA();
        Debug.Log(result); //2
        result = classB.MethodA();
        result = classB.MethodB();
        Debug.Log(result); //2

        //3
        //Polymorphism - UpCasting
        //ClassA classA_fromB = new ClassB();
        //Collider collider = new BoxCollider();
        //4
        //DownCasting
        //ClassB classB_fromA = (ClassB)classA_fromB;

        //5
        //This invokes ClassA default constructor!
        ClassB classB2 = new ClassB();
        Debug.Log("classB2.life: " + classB2.life);

        //6
        //This invokes:
        //  - ClassB(int life, int additionalLife) => 
        //  - ClassB(life + additionalLife) =>
        //  - ClassA( + additionalLife)
        // BUT in REVERSE ORDER!
        ClassB classB3 = new ClassB(10, 5);
        Debug.Log("classB3.life: " + classB3.life);

        //7
        //ClassC classC = new ClassC();
        //classC.PrintContent();
    }
}
