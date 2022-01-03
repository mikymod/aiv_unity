using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePooling : MonoBehaviour
{
    public PoolManager poolManager;
    public Transform spawnPoint;
    public KeyCode fireKey;

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            poolManager.SpawnObject(spawnPoint.position, spawnPoint.rotation);
        }
    }
}
