using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBouncer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3[] positions;
    private int numRaycast = 10;
    private Vector3 inDirection;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        positions = new Vector3[10];
    }

    private void Update()
    {
        Vector3 rayOrigin = transform.position;
        inDirection = Camera.main.transform.forward;
        
        lineRenderer.positionCount = 1;
        positions[0] = rayOrigin;

        for (int i = 1; i < numRaycast; i++)
        {
            if (Physics.Raycast(rayOrigin, inDirection, out RaycastHit hit))
            {
                rayOrigin = hit.point;
                inDirection = Vector3.Reflect(inDirection, hit.normal);
                lineRenderer.positionCount++;
                positions[i] = rayOrigin;

                Debug.DrawLine(hit.point, hit.point + hit.normal, Color.green);
                Debug.DrawLine(hit.point, hit.point + inDirection, Color.blue);
            }
            else
            {
                break;
            }
        }

        lineRenderer.SetPositions(positions);
    }
}
