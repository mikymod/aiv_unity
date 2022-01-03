using UnityEngine;

public class BulletTime : MonoBehaviour
{
    [SerializeField] private float timeScaleFactor = 0.5f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale *= timeScaleFactor;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale *= 1f / timeScaleFactor;
        }
    }
}
