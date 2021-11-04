using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float DestroyAfter = 2f;

    void OnEnable()
    {
        CancelInvoke();
        Invoke("Hide", DestroyAfter);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
