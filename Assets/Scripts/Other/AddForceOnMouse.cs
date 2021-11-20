using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddForceOnMouse : MonoBehaviour {
    public Vector3 ForceToApply;
    public Vector3 TorqueToApply;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    void OnMouseDown () {
        rb.AddForce(ForceToApply);
        rb.AddTorque(TorqueToApply);
    }
}
