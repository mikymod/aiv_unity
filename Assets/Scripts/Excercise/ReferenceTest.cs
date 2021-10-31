using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceTest
{
    public void AddOne(ref int value)
    {
        value += 1;
    }

    public bool InsideCircleAndPerimeter(float r, Vector2 pointToCheck, ref float distanceFromCenter)
    {
        distanceFromCenter = Mathf.Sqrt(pointToCheck.x * pointToCheck.x + pointToCheck.y * pointToCheck.y);
        return r < distanceFromCenter;
    }
}
