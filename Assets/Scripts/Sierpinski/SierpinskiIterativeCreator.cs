using UnityEngine;

public class SierpinskiIterativeCreator : MonoBehaviour
{
    public Transform A, B, C;
    public GameObject middlePointPrefab;
    private Transform AB, BC, CA;

    public GameObject centerPointPrefab;
    private Transform D;

    public int iterations = 3;
    private int numIterations = 0;
    public float offsetY = 5f;

    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTriangle(A, B, C);
    }

    private void GenerateTriangle(Transform A, Transform B, Transform C)
    {
        var point1 = A;
        var point2 = B;
        var point3 = C;

        for (int i = 0; i < iterations; i++)
        {
            var m1 = GenereteVertex(point1, point2, i);
            var m2 = GenereteVertex(point2, point3, i);
            var m3 = GenereteVertex(point3, point1, i);
            
            point1 = m1;
            point2 = m2;
            point3 = m3;
        }
    }

    private Transform GenereteVertex(Transform p1, Transform p2, int iteration)
    {
        var position = (p2.position + p1.position) * 0.5f;
        if (iteration != 0)
        {
            position += new Vector3(0, offsetY, 0);
        }

        var middleGO = Instantiate(middlePointPrefab, position, Quaternion.identity);
        middleGO.GetComponent<StayBetween2Objs>().SetPoints(p1, p2, iteration != 0 ? offsetY : 0);
        middleGO.GetComponent<MeshRenderer>().material = materials[iteration % materials.Length];
        return middleGO.transform;
    }
}
