using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavWPoints : MonoBehaviour
{
    public Transform[] wayPoints;
    public float waitTime;
    private NavMeshAgent agent;
    private float timer;
    private int currWaypoint;

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
