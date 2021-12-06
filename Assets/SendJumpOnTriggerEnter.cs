using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendJumpOnTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Animator>().SetTrigger("Jump");    
    }
}
