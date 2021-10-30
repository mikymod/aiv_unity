using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceVSValue : MonoBehaviour
{
    void Start()
    {
        //Value
        int a = 100;
        int b = a;
        b = 0;
        Debug.Log("a: " + a);

        //Reference
        Goblin g1 = new Goblin();
        Goblin g2 = g1;
        g2.Power = 0;
        Debug.Log("g1.Power: " + g1.Power);

        g1.Power = 100;
        DoublePower(g1);
        Debug.Log("g1.Power: " + g1.Power);

        string message = "Hello Goblin";
        DoubleString(message);
        Debug.Log("message: " + message);

        message = "Hello Goblin";
        DoubleString_Ref(ref message);
        Debug.Log("message: " + message);

        message = "Hello Goblin";
        string DoubleMsg, TripleMsg;
        int charactersCount = CountAndDoubleAndTripleString(message, out DoubleMsg, out TripleMsg);
        Debug.Log("message single: " + message);
    }

    //2
    void DoublePower(Goblin g)
    {
        g.Power *= 2;
    }

    //3
    void DoubleString(string s)
    {
        s = s + s;
    }

    //4
    void DoubleString_Ref(ref string s)
    {
        s = s + s;
    }

    //5
    int CountAndDoubleAndTripleString(string originalString, out string doubledString, out string tripledString)
    {
        doubledString = originalString + originalString;
        tripledString = doubledString + originalString;
        return originalString.Length;
    }
}
