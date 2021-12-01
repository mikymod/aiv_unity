using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPrefabShooter : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletParent;
    public Vector3 ScaleFactor;
    public float Power;
    public Camera Cam;

    GameObject bullet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Cam.ScreenPointToRay(Input.mousePosition);
            bullet = Instantiate(Bullet, Cam.transform.position, Cam.transform.rotation, BulletParent);
            bullet.transform.localScale = ScaleFactor;
            bullet.GetComponent<Rigidbody>().AddForce(Power * r.direction, ForceMode.VelocityChange);
            bullet.GetComponent<Rigidbody>().AddTorque(Power * Random.insideUnitSphere);
        }
    }
}
