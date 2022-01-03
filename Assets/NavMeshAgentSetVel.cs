using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentSetVel : MonoBehaviour
{
    public float speed = 10;
    public float velDrawerDivisor = 3.3f;
    public string HAxisName = "Horizontal";
    public string VAxisName = "Vertical";
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        float HVal = Input.GetAxis(HAxisName) * speed;
        float VVal = Input.GetAxis(VAxisName) * speed;
        navMeshAgent.velocity = new Vector3(HVal, 0, VVal);

        Debug.DrawLine(transform.position, transform.position + (navMeshAgent.velocity / velDrawerDivisor), Color.yellow);
    }
}
