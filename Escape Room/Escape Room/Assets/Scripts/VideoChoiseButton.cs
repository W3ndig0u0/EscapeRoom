using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoChoiseButton : MonoBehaviour
{

    private VideoPlayer videoPlayer;
    
    void Start()
    {
        videoPlayer = FindFirstObjectByType<VideoPlayer>();
    }

    public void ChangeClip(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

    public void ButtonPressed()
    {
        Debug.Log("A");
    }




}
