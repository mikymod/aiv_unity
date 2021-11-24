using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFollowChild : MonoBehaviour
{
    private List<SimpleFollow> followingObjs = new List<SimpleFollow>();

    private void OnTriggerEnter(Collider other)
    {
        if (followingObjs.Contains(other.GetComponent<SimpleFollow>()))
        {
            Debug.Log("You Lose!");
            return;
        }

        var component = other.gameObject.AddComponent<SimpleFollow>();
        component.Followed = followingObjs.Count > 0 ? followingObjs[followingObjs.Count - 1].transform : transform;
        followingObjs.Add(component);
        // other.gameObject.GetComponent<Collider>().enabled = false; 
    }
}
