using System.Collections;
using System.Collections.Generic;

public class Graph <T>
{
    T baseNode;

    public void ReplaceBaseNode(T newBaseNode)
    {
        baseNode = newBaseNode;
    }
}
