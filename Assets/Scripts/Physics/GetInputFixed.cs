using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputFixed : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
            Debug.Log("Update.GetKey");
        if (Input.GetKeyDown(KeyCode.U))
            Debug.Log("Update.GetKeyDown");
        if (Input.GetKeyUp(KeyCode.U))
            Debug.Log("Update.GetKeyUp");
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F))
            Debug.Log("FixedUpdate.GetKey");
        if (Input.GetKeyDown(KeyCode.F))
            Debug.Log("FixedUpdate.GetKeyDown");
        if (Input.GetKeyUp(KeyCode.F))
            Debug.Log("FixedUpdate.GetKeyUp");
    }
}
