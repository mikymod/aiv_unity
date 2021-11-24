using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBShooter : MonoBehaviour
{
    RaycastHit hit;
    public KeyCode ShootKey;
    public ForceMode ForceMod;
    public float Force;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawRay( transform.position, transform.forward * hit.distance, Color.red);
            if (Input.GetKeyDown(ShootKey))
            {
                Rigidbody rb = hit.rigidbody;
                if(rb != null)
                    rb.AddForceAtPosition((hit.point - transform.position).normalized * Force, hit.point, ForceMod);
            }
        }
        else
            Debug.DrawRay(transform.position, transform.forward * 100, Color.green);

    }
}
