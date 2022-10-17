using UnityEngine;

public class CameraController : MonoBehaviour
{

    public void SetCameraFieldValue(float value)
    {

        if (value >= 10)
        {
            Camera.main.fieldOfView = (value * 5) + 40;
        }

        else
        {
            Camera.main.fieldOfView = value * 10 + 10;
        }
    }
}
