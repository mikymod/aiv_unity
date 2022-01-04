using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UpdateIffSleeping : MonoBehaviour
{
    Rigidbody rb;
	NavSurfaceBaker NMBaker;
	bool performUpdate = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		NMBaker = GameObject.Find ("NavMeshSurfacesMng").GetComponent<NavSurfaceBaker> ();
		 
    }

    void Update()
    {
		if (rb.IsSleeping () && performUpdate) {
			performUpdate = false;
			NMBaker.updateSurfaces ();
		}

		if (!rb.IsSleeping())
			//This flag allows us to know if we already updated the navmeshsurface
			performUpdate = true;
    }
}
