using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavUpdateVolume : MonoBehaviour {
	public NavMeshSurface surfaceToUpdate;
	public float maxDistance = 5;
	Vector3 fromSurface2Agent, fromSurf2Volume, fromVolume2Agent;
	float agent2VolumeDistance;

	void Start () {
		UpdateNavMeshVolume ();
	}
	
	void Update () {
        //surfaceToUpdate.transform is static! The Volume on that surface is moving,
        //but surfaceToUpdate.transform is the GameObject transform that has the NavMeshSurface on it!
        fromSurface2Agent = transform.position - surfaceToUpdate.transform.position;
		//This line goes from the surface center to the agent
		Debug.DrawLine (surfaceToUpdate.transform.position, transform.position, Color.red);

		//surfaceToUpdate.center is relative to surfaceToUpdate.transform.position!
		fromVolume2Agent = transform.position - (surfaceToUpdate.transform.position + surfaceToUpdate.center);
        //This line goes from the volume center to the agent
        Debug.DrawLine ((surfaceToUpdate.transform.position + surfaceToUpdate.center), transform.position, Color.yellow);
        agent2VolumeDistance = fromVolume2Agent.magnitude;

		if (agent2VolumeDistance >= maxDistance)
			UpdateNavMeshVolume ();
	}

	void UpdateNavMeshVolume () {
		surfaceToUpdate.RemoveData ();
		//surfaceToUpdate.center is relative to surfaceToUpdate.transform.position!
		surfaceToUpdate.center = fromSurface2Agent;
		surfaceToUpdate.BuildNavMesh ();
	}
}
