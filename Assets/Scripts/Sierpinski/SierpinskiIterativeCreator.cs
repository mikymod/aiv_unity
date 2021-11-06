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
        var ABGO = Instantiate(middlePointPrefab, (B.position + A.position) * 0.5f + Vector3.up * numIterations * offsetY, Quaternion.identity);
        ABGO.GetComponent<StayBetween2Objs>().SetPoints(A, B, numIterations * offsetY);
        ABGO.GetComponent<MeshRenderer>().material = materials[numIterations % materials.Length];

        var BCGO = Instantiate(middlePointPrefab, (C.position + B.position) * 0.5f + Vector3.up * numIterations * offsetY, Quaternion.identity);
        BCGO.GetComponent<StayBetween2Objs>().SetPoints(B, C, numIterations * offsetY);
        BCGO.GetComponent<MeshRenderer>().material = materials[numIterations % materials.Length];

        var CAGO = Instantiate(middlePointPrefab, (A.position + C.position) * 0.5f + Vector3.up * numIterations * offsetY, Quaternion.identity);
        CAGO.GetComponent<StayBetween2Objs>().SetPoints(C, A, numIterations * offsetY);
        CAGO.GetComponent<MeshRenderer>().material = materials[numIterations % materials.Length];

        var DGO = Instantiate(centerPointPrefab, (ABGO.transform.position + BCGO.transform.position + CAGO.transform.position) / 3f + Vector3.up * numIterations * offsetY, Quaternion.identity);
        DGO.GetComponent<StayOnCOM>().SetPoints(ABGO.transform, BCGO.transform, CAGO.transform, numIterations * offsetY);

        numIterations++;

        if (numIterations < iterations)
        {
            GenerateTriangle(ABGO.transform, BCGO.transform, CAGO.transform);
        }
    }
}
