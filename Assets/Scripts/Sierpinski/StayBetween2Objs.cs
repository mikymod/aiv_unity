using UnityEngine;

public class StayBetween2Objs : MonoBehaviour
{
    private Transform point1;
    private Transform point2;
    private float offsetY;

    public void SetPoints(Transform point1, Transform point2, float offsetY)
    {
        this.point1 = point1;
        this.point2 = point2;
        this.offsetY = offsetY;
    }

    void Update()
    {
        transform.position = (point1.position + point2.position) * 0.5f + Vector3.up * offsetY;
    }
}
