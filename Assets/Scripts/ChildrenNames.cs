using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenNames : MonoBehaviour
{
    string childrenTree = "";

    void Start()
    {
        childrenTree += "CHILDREN LIST\n";
        printChildren(0, this.transform);
        print(childrenTree);
    }

    void printChildren(int d, Transform t)
    {
        int n = t.childCount;
        for (int i = 0; i < n; i++)
        {
            Transform currChild = t.GetChild(i);
            childrenTree += getDepthSeparator(d) + currChild.name + "\n";
            if (currChild.childCount > 0)
                printChildren(d+1, currChild.transform);
        }
    }

    string getDepthSeparator(int d)
    {
        string depthSeparator = "";
        for (int i = 0; i < d; i++)
            depthSeparator += "\t";
        return depthSeparator;
    }
}
