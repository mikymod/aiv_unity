using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogContextCaller : MonoBehaviour
{
    void Start()
    {
        transform.parent.GetComponent<DebugLogContext>().NotifyMe(gameObject);
    }
}
