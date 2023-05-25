using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
   private void Start()
    {
        ResizeScreen();
    }

    private void Update()
    {
        ResizeScreen();
    }

private void ResizeScreen()
{
    float targetAspectRatio = 9f / 16f; // Adjust this value to match your desired aspect ratio (portrait mode)
    float currentAspectRatio = (float)Screen.width / Screen.height;

    float scaleFactor = (currentAspectRatio / targetAspectRatio) * 3;

    if (scaleFactor > 1f)
    {
        Camera.main.orthographicSize = Screen.width / (2f * scaleFactor);
    }
    else
    {
        Camera.main.orthographicSize = Screen.width / 2f;
    }
}

}
