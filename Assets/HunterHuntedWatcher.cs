using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterHuntedWatcher : MonoBehaviour
{
    public float distance = 2f;
    private Vector3 minScale = new Vector3(1f, 0.01f, 1f);
    private float speed = 5f;
    
    private Transform hunter;
    private Transform hunted;

    void Start()
    {
        hunter = GameObject.FindObjectOfType<LerpHunter>().transform;
        hunted = GameObject.FindObjectOfType<ObjMoveTranslation>().transform;
    }

    void Update()
    {
        var distanceHunter = Vector3.Distance(transform.position, hunter.position);
        var distanceHunted = Vector3.Distance(transform.position, hunted.position);

        var minDistance = Mathf.Min(distanceHunter, distanceHunted);

        if (minDistance < distance)
        {
            transform.parent.transform.localScale = Vector3.Lerp(transform.parent.transform.localScale, minScale, Time.deltaTime * speed);
        }
        else
        {
            transform.parent.transform.localScale = Vector3.Lerp(transform.parent.transform.localScale, Vector3.one, Time.deltaTime * speed);
        }
    }
}
