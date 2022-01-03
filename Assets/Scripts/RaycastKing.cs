using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastKing : MonoBehaviour
{
    [SerializeField] private Transform soldier0;
    [SerializeField] private Transform soldier1;
    [SerializeField] private Transform soldier2;
    [SerializeField] private Transform soldier3;
    [SerializeField] private float distanceFromKing;
    [SerializeField] private float knightSpeed = 10f;
    [SerializeField] private float knightRotSpeed = 10f;
    private float knightPosOffset = 2f;

    private void Start()
    {
        soldier0.transform.position = transform.position + transform.forward.normalized * distanceFromKing;
        soldier1.transform.position = transform.position + -transform.forward.normalized * distanceFromKing;
        soldier2.transform.position = transform.position + transform.right.normalized * distanceFromKing;
        soldier3.transform.position = transform.position + -transform.right.normalized * distanceFromKing;
    }

    private void Update()
    {
        UpdateSoldier(soldier0, transform.forward);
        UpdateSoldier(soldier1, -transform.forward);
        UpdateSoldier(soldier2, transform.right);
        UpdateSoldier(soldier3, -transform.right);
    }

    void UpdateSoldier(Transform soldier, Vector3 orientation)
    {
        Debug.DrawLine(transform.position, transform.position + orientation * 100, Color.white);

        if (Physics.Raycast(transform.position, orientation, out RaycastHit hit, distanceFromKing))
        {
            Debug.DrawLine(hit.point, hit.point + hit.normal, Color.green);
            float distanceFromWall = Vector3.Distance(transform.position, hit.point);
            soldier.transform.position = Vector3.Lerp(soldier.transform.position, transform.position + orientation.normalized * (distanceFromWall - knightPosOffset), knightSpeed * Time.deltaTime);
            soldier.transform.rotation = Quaternion.Slerp(soldier.transform.rotation, Quaternion.LookRotation(hit.normal, Vector3.up), knightRotSpeed * Time.deltaTime);
        }
        else
        {
            soldier.transform.position = Vector3.Lerp(soldier.transform.position, transform.position + orientation.normalized * distanceFromKing, knightSpeed * Time.deltaTime);
            soldier.transform.rotation = Quaternion.Slerp(soldier.transform.rotation, Quaternion.LookRotation(Vector3.forward, Vector3.up), knightRotSpeed * Time.deltaTime);
        }
    }
}
