using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMB : MonoBehaviour
{
    void Start()
    {
        PointClass pc = new PointClass(1, 1);
        PointStruct ps = new PointStruct(1, 1);
        Debug.Log("pc: " + pc.x + "," + pc.y);
        Debug.Log("ps: " + ps.x + "," + ps.y);
        Vector2 offset = new Vector2(5, 5);
        AddOffsetToPointClass(offset, pc);
        AddOffsetToPointStruct(offset, ps);
        Debug.Log("pc: " + pc.x + "," + pc.y);
        Debug.Log("ps: " + ps.x + "," + ps.y);

        //Structs can implement interfaces
        ps.PrintContent();
    }

    //By reference
    void AddOffsetToPointClass(Vector2 offset, PointClass pc)
    {
        pc.x += offset.x;
        pc.y += offset.y;
    }
    //By value
    void AddOffsetToPointStruct(Vector2 offset, PointStruct ps)
    {
        ps.x += offset.x;
        ps.y += offset.y;
    }
}
