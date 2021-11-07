using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossCalculator : MonoBehaviour
{
    public Transform A, B, C;
    public Transform CrossAB_AC;

    void Update()
    {
        CrossAB_AC.position = Vector3.Cross((B.position - A.position), (C.position - A.position));
    }
}
