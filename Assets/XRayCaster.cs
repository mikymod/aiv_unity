using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayCaster : MonoBehaviour
{
    [SerializeField] private int numX;
    [SerializeField] private int numY;
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool useNormal;


    // Start is called before the first frame update
    void Start()
    {
        List<RaycastHit> hits = new List<RaycastHit>();
        var offsetX = (float) Screen.width / numX;
        var offsetY = (float) Screen.height / numY;

        for (int y = 0; y < numY; y++)
        {
            for (int x = 0; x < numX; x++)
            {
                var ray = Camera.main.ScreenPointToRay(new Vector2(x * offsetX, y * offsetY));
                Debug.DrawRay(ray.origin, ray.direction, Color.blue, 60);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    hits.Add(hit);
                }
            }
        }

        foreach (var hit in hits)
        {
            if (useNormal)
            {
                Instantiate(prefab, hit.point, Quaternion.Euler(hit.normal.x, hit.normal.y, hit.normal.z));
            }
            else
            {
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
    }
}
