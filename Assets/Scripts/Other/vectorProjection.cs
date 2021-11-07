using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorProjection : MonoBehaviour
{
    public Transform A, B, C;
    public Transform ProjAC_on_AB;
    public bool useDotProduct;

    // Update is called once per frame
    void Update()
    {
        Vector3 AB = (B.position - A.position);
        Vector3 AC = (C.position - A.position);
        Vector3 ABnormalized = (B.position - A.position).normalized;
        Vector3 ACnormalized = (C.position - A.position).normalized;
        if (!useDotProduct) {
            ProjAC_on_AB.position = Vector3.Project(C.position - A.position, ABnormalized);
        }
        else {
            //dot(AB,AC) = |a||b|cos(alfa).
            //If a and b are normalized, |a| = |b| = 1, then dot(AB,AC) = cos(alfa)
            float cosalfa = Vector3.Dot(ABnormalized, ACnormalized);
            //In a right rectangle abc (c is the hypotenuse): cos(alfa) = a/c, where a is the length of the projection we are searching for
            float ProjAC_on_AB_lenght = (C.position - A.position).magnitude * cosalfa;
            ProjAC_on_AB.position = ABnormalized * ProjAC_on_AB_lenght;
        }
    }
}
