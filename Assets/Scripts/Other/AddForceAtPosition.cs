using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceAtPosition : MonoBehaviour {
    public float Power = 5;
    Vector3 ForceToApply;
    Rigidbody rb;
    RaycastHit hitInfo;
    RaycastHit[] hitsInfo;
    Ray customRay;
    bool fire = false;
    public Camera cam;
    public Transform DebugTarget;

    [SerializeField] private GameObject hole;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            fire = true;
    }
    void FixedUpdate () {
        customRay = cam.ScreenPointToRay(Input.mousePosition);

        if (fire && Physics.Raycast(customRay, out hitInfo))
        {
            fire = false;
            rb = hitInfo.collider.transform.GetComponent<Rigidbody>();
            if (rb == null)
                return;
            DebugTarget.position = hitInfo.point;

            var go = Instantiate(hole, hitInfo.point + new Vector3(0, 0, -0.01f), Quaternion.identity); // custom offset
            go.transform.rotation = Quaternion.LookRotation(-hitInfo.normal, Vector3.up) * Quaternion.AngleAxis(Random.Range(0, 360), transform.forward);
            go.transform.parent = rb.gameObject.transform;

            var localPosition = rb.gameObject.transform.InverseTransformPoint(go.transform.position);
            var localDirection = rb.gameObject.transform.InverseTransformDirection(go.transform.forward); 
            Debug.Log($"localPosition: {localPosition}");
            Debug.Log($"localDirection: {localDirection}");
            // var clampedLocalPosition = Vector2.ClampMagnitude(localPosition, 0.4f);
            var clampedLocalPosition = new Vector3(
                Mathf.Clamp(localPosition.x, -0.3f, 0.3f),
                Mathf.Clamp(localPosition.y, -0.3f, 0.3f),
                Mathf.Clamp(localPosition.z, -0.3f, 0.3f)
            );
            // Debug.Log($"clamped: {clampedLocalPosition}");
            go.transform.position = rb.gameObject.transform.TransformPoint(clampedLocalPosition + localDirection * -0.21f);


            ForceToApply = (hitInfo.point - cam.transform.position).normalized * Power;
            rb.AddForceAtPosition(ForceToApply, hitInfo.point);
        }
    }
}
