using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionForce : MonoBehaviour {
    public bool explode;
    public float strenght, upModifier;
    public float explosionRadius;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (explode)
        {
            explode = false;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
            for (int i = 0; i < hitColliders.Length; i++)
            {
                rb = hitColliders[i].transform.GetComponent<Rigidbody>();
                if (rb == null)
                    continue;
                rb.AddExplosionForce(strenght, transform.position, explosionRadius, upModifier, ForceMode.Impulse);
            }
        }	
	}
}
