using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogContext : MonoBehaviour
{
    public GameObject PrefabGO;
    public int N;

    void Start()
    {
        for (int i = 0; i < N; i++)
        {
            Instantiate(PrefabGO, transform);
        }
    }

    public void NotifyMe(GameObject senderGO)
    {
        //If you click on this Debug message, the GameObject senderGO will be highlighted in the Hierarchy
        Debug.Log("Here I am! " + senderGO.name, senderGO);
        //..while nothing happens in this "normal" case:
        //Debug.Log("Here I am! " + senderGO.name);
    }
}
