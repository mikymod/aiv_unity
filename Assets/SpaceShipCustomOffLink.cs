using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaceShipCustomOffLink : MonoBehaviour
{
    // public OffMeshLinkMoveMethod Method = OffMeshLinkMoveMethod.Parabola;
    public AnimationCurve YAnimCurve = new AnimationCurve();
    public AnimationCurve XAnimCurve = new AnimationCurve();
    public float TravelDuration = 0.5f;
    public float endPosReachedNormalDistance = 0.05f;
    public Transform middleTravelPoint1;
    public Transform middleTravelPoint2;

    NavMeshAgent agent;
    bool prevStatus = false;
    bool currStatus = false;
    float normalizedTime;

    OffMeshLinkData data;
    Vector3 endPos, startPos, firstStepPos, secondStepPos;
    float rotationAngle;
    int inverseRotation;

    float currAngle = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;
    }

    private void Update()
    {
        currStatus = agent.isOnOffMeshLink;
        if (currStatus)
        {
            if(prevStatus != currStatus)
            {
                SetStartEndPos();
                normalizedTime = 0;
                // agent.updateRotation = false;
            }

            Curve();

            if(normalizedTime >= 1.0)
            {
                agent.CompleteOffMeshLink();
                // agent.updateRotation = true;
                currAngle = 0;
            }
        }
        prevStatus = currStatus;
    }

    void SetStartEndPos()
    {
        data = agent.currentOffMeshLinkData;
        startPos = agent.transform.position;
        endPos = data.endPos + Vector3.up * agent.baseOffset;

        // Evaluate middle points
        if (Vector3.Distance(startPos, middleTravelPoint1.position) < Vector3.Distance(startPos, middleTravelPoint2.position))
        {
            firstStepPos = middleTravelPoint1.position;
            secondStepPos = middleTravelPoint2.position;
        }
        else
        {
            firstStepPos = middleTravelPoint2.position;
            secondStepPos = middleTravelPoint1.position;
        }

        Debug.Log($"agent:{agent.transform.position}");
        Debug.Log($"pos:{firstStepPos}");

        inverseRotation = agent.transform.position.x < firstStepPos.x ? -1 : 1;
        rotationAngle = Vector3.Angle(Vector3.up, firstStepPos - agent.transform.position);
    }
    

    void Curve()
    {
        float travelStepTime = 1f / 3f;

        if (normalizedTime < travelStepTime)
        {
            currAngle += rotationAngle * Mathf.Sign(agent.transform.forward.z) * inverseRotation * Time.deltaTime;
            agent.transform.position = Vector3.Lerp(startPos, firstStepPos, normalizedTime * TravelDuration);
            agent.transform.rotation *= Quaternion.Euler(0, 0, agent.transform.rotation.z * Mathf.Deg2Rad + currAngle);
        }
        else if (normalizedTime >= travelStepTime && normalizedTime < travelStepTime * 2)
        {
            currAngle -= rotationAngle * Mathf.Sign(agent.transform.forward.z) * inverseRotation * Time.deltaTime;
            agent.transform.position = Vector3.Lerp(firstStepPos, secondStepPos, (normalizedTime - travelStepTime) * TravelDuration);
            agent.transform.rotation *= Quaternion.Euler(0, 0, agent.transform.rotation.z * Mathf.Deg2Rad + currAngle);
        }
        else if (normalizedTime >= travelStepTime * 2 && normalizedTime < travelStepTime * 3)
        {
            currAngle -= rotationAngle * Mathf.Sign(agent.transform.forward.z) * inverseRotation * Time.deltaTime;
            agent.transform.position = Vector3.Lerp(secondStepPos, endPos, (normalizedTime - travelStepTime * 2) * TravelDuration);
            agent.transform.rotation *= Quaternion.Euler(0, 0, agent.transform.rotation.z * Mathf.Deg2Rad + currAngle);
        }
        // else
        // {
        //     var rotation = Quaternion.LookRotation(endPos - agent.transform.position, Vector3.up);
        //     // agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotation, (normalizedTime - travelStep * 3) * TravelDuration);
        // }
        normalizedTime += Time.deltaTime / TravelDuration;
    }
}
