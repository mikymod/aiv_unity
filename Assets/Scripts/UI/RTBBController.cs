using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTBBController : MonoBehaviour
    {
    public float Speed = 1;
    public string H1AxisName, V1AxisName;
    public string H2AxisName, V2AxisName;

    float h1, h2, v1, v2;

    [SerializeField] private RectTransform player1, player2;
    [SerializeField] private RectTransform radar;

    void Update()
    {
        h1 = Input.GetAxis(H1AxisName) * Time.deltaTime * Speed;
        v1 = Input.GetAxis(V1AxisName) * Time.deltaTime * Speed;
        h2 = Input.GetAxis(H2AxisName) * Time.deltaTime * Speed;
        v2 = Input.GetAxis(V2AxisName) * Time.deltaTime * Speed;

        //Move Players
        player1.transform.position += new Vector3(h1, v1);
        player2.transform.position += new Vector3(h2, v2);

        // // Clamp
        // var p1ClampedX = Mathf.Clamp(player1.transform.position.x, -40f, 40f);
        // var p1ClampedY = Mathf.Clamp(player1.transform.position.y, -40f, 40f);
        // var p2ClampedX = Mathf.Clamp(player2.transform.position.x, -40f, 40f);
        // var p2ClampedY = Mathf.Clamp(player2.transform.position.y, -40f, 40f);
        // player1.transform.position = new Vector2(p1ClampedX, p1ClampedY);
        // player2.transform.position = new Vector2(p2ClampedX, p2ClampedY);

        //Adjust RadarBoundingBox around Players
        float offsetMinX;
        float offsetMinY;
        float offsetMaxX;
        float offsetMaxY;

        offsetMinX = Mathf.Clamp(player1.localPosition.x < player2.localPosition.x ? player1.localPosition.x : player2.localPosition.x, -330f, 330f);
        offsetMinY = Mathf.Clamp(player1.localPosition.y < player2.localPosition.y ? player1.localPosition.y : player2.localPosition.y, -330, 160f);
        offsetMaxX = Mathf.Clamp(player1.localPosition.x > player2.localPosition.x ? player1.localPosition.x : player2.localPosition.x, -330f, 330f);
        offsetMaxY = Mathf.Clamp(player1.localPosition.y > player2.localPosition.y ? player1.localPosition.y : player2.localPosition.y, -330f, 160f);
        
        
        radar.offsetMin = new Vector2(offsetMinX, offsetMinY) - new Vector2(player1.rect.width / 2f, player1.rect.height / 2f);
        radar.offsetMax = new Vector2(offsetMaxX, offsetMaxY) + new Vector2(player2.rect.width / 2f, player2.rect.height / 2f);
        Debug.Log(radar.offsetMin);
        Debug.Log(radar.offsetMax);
    }
}
