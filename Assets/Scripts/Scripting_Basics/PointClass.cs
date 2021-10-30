using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PointStruct: IPrintable
{
    public float x, y;

    public PointStruct(float X, float Y)
    {
        x = X;
        y = Y;
    }

    public void PrintContent()
    {
        string structDescription = string.Format("--- PointStruct ---\nx: {0}\ny:{1}", x, y);
        Debug.Log(structDescription);
    }
}

public class PointClass
{
    public float x, y;
    public PointClass(float X, float Y)
    {
        x = X;
        y = Y;
    }
}
