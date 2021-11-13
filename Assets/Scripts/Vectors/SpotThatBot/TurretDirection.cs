using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class TurretDirection : MonoBehaviour
{
    public Transform target;
    public Transform gun;
    public Transform laserStart;
    private LineRenderer gunLineRenderer;

    private void Awake()
    {
        gunLineRenderer = gun.gameObject.GetComponent<LineRenderer>();    
    }

    private void Update()
    {
        // Rotate turret around Y axis
        var dir = target.position - transform.position;
        dir = new Vector3(dir.x, 0, dir.z);
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

        // Rotate gun around x axis
        var v1 = target.position - gun.transform.position;
        if (target.position.y < gun.transform.position.y)
        {
            gunLineRenderer.enabled = false;
        }
        else
        {
            gunLineRenderer.enabled = true;
            gunLineRenderer.SetPositions(new Vector3[] {laserStart.position, target.position});
            var proj = Vector3.Dot(v1.normalized, transform.forward);
            var angle = Mathf.Acos(proj) * Mathf.Rad2Deg;

            var transformRotation = transform.rotation.eulerAngles;
            gun.transform.rotation = Quaternion.Euler(0f, transformRotation.y, 0f) * Quaternion.Euler(-angle, 0f, 0f);
            
        }

    }
}
