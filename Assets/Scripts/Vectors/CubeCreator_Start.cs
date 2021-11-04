using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator_Start : MonoBehaviour
{
    public Transform A, B, C, D;
    public GameObject prefabV;
    Transform E, F, G, H;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(prefabV);
            if (i == 0) { go.name = "E";  E = go.transform; }
            else if (i == 1) { go.name = "F"; F = go.transform; }
            else if (i == 2) { go.name = "G"; G = go.transform; }
            else if (i == 3) { go.name = "H"; H = go.transform; }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 AB = B.position - A.position;
        Vector3 AD = D.position - A.position;
        Vector3 AC = C.position - A.position;
        F.position = AB + AC;
        G.position = AB + AD;
        H.position = AC + AD;
        E.position = G.position + (F.position - B.position);
        
        Debug.DrawLine(A.position, D.position);
        Debug.DrawLine(A.position, C.position);
        Debug.DrawLine(D.position, H.position);
        Debug.DrawLine(H.position, E.position);
        Debug.DrawLine(F.position, E.position);
        Debug.DrawLine(E.position, G.position);
        Debug.DrawLine(G.position, B.position);
        Debug.DrawLine(B.position, F.position);
        Debug.DrawLine(A.position, B.position);
        Debug.DrawLine(C.position, H.position);
        Debug.DrawLine(C.position, G.position);
    }
}
