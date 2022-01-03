using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public KeyCode fireKey;

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
