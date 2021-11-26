using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveTransRot : MonoBehaviour
{
    private const float MaxDistance = 20f;
    public float speed = 5f;
    public float speedRotation = 50f;

    [SerializeField] private float hoverDistance = 3f;

    // Update is called once per frame
    void Update()
    {
        var hAx = Input.GetAxis("Horizontal");
        var vAx = Input.GetAxis("Vertical");
        // transform.Rotate(new Vector3(0, hAx, 0) * speedRotation * Time.deltaTime);

        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, MaxDistance);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * MaxDistance, Color.yellow);
        Debug.DrawLine(hit.point, hit.point + hit.normal * 10, Color.green);

        Vector3 newForward = Vector3.Cross(hit.normal, -transform.right);
        Debug.DrawLine(hit.point, hit.point + newForward, Color.blue);

        transform.Rotate(0f, hAx, 0f);
        transform.forward = Vector3.Lerp(transform.forward, newForward, speed * Time.deltaTime);
        transform.Translate(new Vector3(0f, 0f, vAx) * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, hit.point.y + hoverDistance, transform.position.z);
    }
}
