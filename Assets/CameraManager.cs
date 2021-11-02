using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    private int cameraIndex = 0;

    private void Start()
    {
        DisableAllCameras();

        cameras[0].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameras[cameraIndex].gameObject.SetActive(false);

            cameraIndex++;
            if (cameraIndex >= cameras.Length)
                cameraIndex = 0;
            cameras[cameraIndex].gameObject.SetActive(true);
        }
    }

    private void DisableAllCameras()
    {
        foreach (var camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }
    }
}
