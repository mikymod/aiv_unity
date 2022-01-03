using UnityEngine;

public class InstantiateColumn : MonoBehaviour
{
    public int N = 1;
    public float offsetPos = 1f;
    public Vector3 endScale = new Vector3(0.1f, 0.1f, 0.1f);
    public GameObject prefabs = default;
    void Start()
    {
        var position = transform.position;
        var offset = offsetPos;
        var deltaScale = (transform.localScale - endScale) / N;
        var currentScale = transform.localScale;
        var partToFollow = transform;

        for (int i = 0; i < N; i++)
        {
            var child = Instantiate(prefabs, position + Vector3.up * offset, Quaternion.identity);

            offset += offsetPos;

            // FIXME: last column part must have scale == endScale;
            currentScale = Vector3.Lerp(currentScale, endScale, Vector3.Magnitude(endScale));
            child.transform.localScale = currentScale;
        
            child.GetComponent<CubeColumnFollower>().PartToFollow = partToFollow;
            partToFollow = child.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
