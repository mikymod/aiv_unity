using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletRoot;
    public int poolSize = 10;

    public Queue<GameObject> queue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var go = Instantiate(BulletPrefab, BulletRoot);
            queue.Enqueue(go);
            go.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject(Vector3 position, Quaternion rotation)
    {
        if (queue.Peek().activeSelf)
        {
            return;
        }

        var spawned = queue.Dequeue();
        spawned.transform.position = position;
        spawned.transform.rotation = rotation;
        spawned.SetActive(true);
        queue.Enqueue(spawned);
    }
}
