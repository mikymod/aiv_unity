using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerp : MonoBehaviour
{
    public Transform fromOrientation, toOrientation, currOrientation;
    [Range(0, 1)]
    public float slerpFraction;

    void Update()
    {
        //--- Spherical Linear Interpolation: Slerp
        currOrientation.rotation = Quaternion.Slerp(fromOrientation.rotation,
                                                    toOrientation.rotation,
                                                    slerpFraction);
    }
}
