using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavWPointsSearchSphere : MonoBehaviour
{
    public Transform[] wayPoints;
    public float waitTime;
    public Transform follow;

    private NavMeshAgent agent;
    private float timer;
    private int currWaypoint;
    private bool patroling;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = 0f;
        currWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, 10f);
        foreach (var collider in colliders)
        {
            if (collider.transform == follow)
            {
                patroling = false;
                agent.destination = follow.position;
            }
            else
            {
                patroling = true;
            }   
        }

        if (patroling)
        {
            if (timer < waitTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                if (agent.destination != wayPoints[currWaypoint].position)
                {
                    agent.destination = wayPoints[currWaypoint].position;
                }

                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    timer = 0;
                    currWaypoint = (currWaypoint + 1) % wayPoints.Length;
                }
            }
        }

    }
}
