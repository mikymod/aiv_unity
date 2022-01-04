using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavSurfaceBaker : MonoBehaviour {
	public NavMeshSurface[] surfaces;

	// Use this for initialization
	void Start () {
		updateSurfaces ();
	}

	public void updateSurfaces(){
		for (int i = 0; i < surfaces.Length; i++) {
			surfaces [i].RemoveData ();
			surfaces [i].BuildNavMesh ();
		}
	}
}
