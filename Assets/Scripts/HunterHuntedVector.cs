using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterHuntedVector : MonoBehaviour
{
    public Transform hunted;
    public Transform hunterForward;

    void Update()
    {
        var distance = Vector3.Distance(transform.position, hunted.position);
        var dir = hunted.position - transform.position;

        var cosAlpha = Vector3.Dot(dir.normalized, hunterForward.forward);
        var alpha = Mathf.Acos(cosAlpha);
        var alphaInDegree = alpha * Mathf.Rad2Deg;
      
        var projV = Vector3.Cross(hunterForward.forward, dir.normalized);
        if (Mathf.Sign(alphaInDegree) > 0 && Mathf.Sign(projV.y) < 0 || Mathf.Sign(alphaInDegree) < 0 && Mathf.Sign(projV.y) < 0)
        {
            alphaInDegree = 360 - alphaInDegree;
        }

        transform.rotation = Quaternion.Euler(0, alphaInDegree, 0);
        transform.localScale = new Vector3(1, 0, distance);
    }
}
