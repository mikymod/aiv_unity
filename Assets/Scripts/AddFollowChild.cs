using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddFollowChild : MonoBehaviour
{
    private List<SimpleFollow> followingObjs = new List<SimpleFollow>();
    [SerializeField] private Material followMat;

    private void OnTriggerEnter(Collider other)
    {
        if (followingObjs.Contains(other.GetComponent<SimpleFollow>()))
        {
            Debug.Log("You Lose!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        var component = other.gameObject.AddComponent<SimpleFollow>();
        other.gameObject.GetComponent<Renderer>().material = followMat;
        component.Followed = followingObjs.Count > 0 ? followingObjs[followingObjs.Count - 1].transform : transform;
        followingObjs.Add(component);
    }
}
