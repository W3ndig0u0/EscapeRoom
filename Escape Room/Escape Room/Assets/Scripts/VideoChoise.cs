using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoChoise : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void ChangeClip(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

    public void ChangeClipAuto(VideoClip clip)
    {
    if ((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false))
        {
            videoPlayer.clip = clip;
            videoPlayer.Play();
        }        
    }

}
