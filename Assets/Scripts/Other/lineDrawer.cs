using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class lineDrawer : MonoBehaviour
{
    public Color c;
    public Transform StartT, EndT;
    private void Update()
    {
        Debug.DrawLine(StartT.position, EndT.position, c);
    }
}
