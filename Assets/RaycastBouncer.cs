using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBouncer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> positions;
    private int numRaycast = 10;
    private Vector3 inDirection;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        positions = new List<Vector3>();
    }

    private void Update()
    {
        Vector3 rayOrigin = transform.position;
        inDirection = Camera.main.transform.forward;
        lineRenderer.positionCount = 1;
        positions.Add(rayOrigin);

        for (int i = 0; i < numRaycast; i++)
        {
            positions[i] = rayOrigin;
            if (Physics.Raycast(rayOrigin, inDirection, out RaycastHit hit))
            {
                rayOrigin = hit.point;
                inDirection = Vector3.Reflect(inDirection, hit.normal);
                lineRenderer.positionCount++;
                positions.Add(rayOrigin);

                Debug.DrawLine(hit.point, hit.point + hit.normal, Color.green);
                Debug.DrawLine(hit.point, hit.point + inDirection, Color.blue);
            }
            else
            {
                break;
            }
        }

        lineRenderer.SetPositions(positions.ToArray());
    }
}
