using UnityEngine;

public class SpriteSelector : MonoBehaviour
{
    public Camera cam;
    public GameObject[] sprites;

    private GameObject currentSprite;

    private void Start()
    {
        DisableAllSprites();   
        currentSprite = sprites[0]; 
    }

    // Update is called once per frame
    void Update()
    {
        var dir = (cam.transform.position - transform.position);
        Debug.DrawLine(transform.position, transform.position + dir, Color.red);

        var invert = false;
        var projForwardToCam = Vector3.Dot(transform.forward, dir.normalized);
        var projRightToCam = Vector3.Dot(transform.right, dir.normalized);
        if ((Mathf.Sign(projForwardToCam) > 0 && Mathf.Sign(projRightToCam) < 0) || (Mathf.Sign(projForwardToCam) < 0 && Mathf.Sign(projRightToCam) < 0))
        {
            invert = true;
        }

        var projForwardAngle = Mathf.Acos(projForwardToCam) * Mathf.Rad2Deg;
        if (invert)
        {
            projForwardAngle = 360f - projForwardAngle;
        }

        // Alternative Approach:
        // var dir = cam.transform.position - transform.position;
        // var projForwardAngle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        // if (projForwardAngle < 0)
        // {
        //     projForwardAngle += 360f;
        // }

        Debug.Log(projForwardAngle);

        currentSprite.SetActive(false);
        var angleShift = (360f / sprites.Length)/4;
        if (projForwardAngle >= 45 + angleShift && projForwardAngle < 90 + angleShift)
        {
            // 0
            currentSprite = sprites[0];
        }
        else if (projForwardAngle >= 0 + angleShift && projForwardAngle < 45 + angleShift)
        {
            // 1
            currentSprite = sprites[1];
        }
        else if (projForwardAngle >= 315 + angleShift || projForwardAngle < 0 + angleShift)
        {
            // 2
            currentSprite = sprites[2];
        }
        else if (projForwardAngle >= 270 + angleShift && projForwardAngle < 315 + angleShift)
        {
            // 3
            currentSprite = sprites[3];
        }
        else if (projForwardAngle >= 225 + angleShift && projForwardAngle < 270 + angleShift)
        {
            // 4
            currentSprite = sprites[4];
        }
        else if (projForwardAngle >= 180 + angleShift && projForwardAngle < 225 + angleShift)
        {
            // 5
            currentSprite = sprites[5];
        }
        else if (projForwardAngle >= 135 + angleShift && projForwardAngle < 180 + angleShift)
        {
            // 6
            currentSprite = sprites[6];
        }
        else if (projForwardAngle >= 90 + angleShift && projForwardAngle < 135 + angleShift)
        {
            // 7
            currentSprite = sprites[7];
        }

        currentSprite.SetActive(true);
    }

    private void DisableAllSprites()
    {
        foreach (var sprite in sprites)
        {
            sprite.SetActive(false);
        }
    }
}
