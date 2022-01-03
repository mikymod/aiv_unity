using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathVisualizer : MonoBehaviour
{
    private NavMeshAgent agent;
    private LineRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshPath path = new NavMeshPath();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                agent.CalculatePath(hitInfo.point, path);
                
                switch(path.status)
                {
                    case NavMeshPathStatus.PathInvalid:
                        rend.startColor = Color.red;
                        rend.endColor = Color.red;
                        rend.positionCount = 2;
                        rend.SetPositions(new Vector3[] {transform.position + Vector3.up, hitInfo.point + Vector3.up});
                        break;
                    case NavMeshPathStatus.PathComplete:
                    case NavMeshPathStatus.PathPartial:
                        rend.startColor = path.status == NavMeshPathStatus.PathComplete ? Color.green : Color.yellow;
                        rend.endColor = path.status == NavMeshPathStatus.PathComplete ? Color.green : Color.yellow;
                        rend.positionCount = path.corners.Length;
                        rend.SetPositions(path.corners);
                        break;
                }
            }
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.path = path;
            }
        }
    }
}
