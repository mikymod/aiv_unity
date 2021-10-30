using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMB : MonoBehaviour
{
    void Start()
    {
        Graph<ClassA> graphMadeOfClassANodes = new Graph<ClassA>();
        graphMadeOfClassANodes.ReplaceBaseNode(new ClassA());
    }
}
