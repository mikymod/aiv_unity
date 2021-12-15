using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform label;
    [SerializeField] private int numPoints;
    private LineRenderer lineRenderer;
    private Vector3[] points;
    private float fixedDistance;
    private Vector3 currPoint;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        points = new Vector3[numPoints];
        fixedDistance = Vector2.Distance(player.position, label.position);
    }

    private void Update()
    {
        for (int i = 0; i < numPoints; i++)
        {
            var delta = fixedDistance / numPoints * i;
            currPoint = new Vector3(player.position.x, player.position.y + delta, player.position.z);
            points[i] = currPoint;
        }

        lineRenderer.positionCount = numPoints;
        lineRenderer.SetPositions(points);       
    }
}
