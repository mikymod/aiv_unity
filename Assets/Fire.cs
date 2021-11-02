using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform SpawnPoint;
    public KeyCode fireKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            Instantiate(bulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
        }
    }
}
