using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
        private VideoPlayer videoPlayer;


    void Start()
    {
        videoPlayer = FindFirstObjectByType<VideoPlayer>();
        videoPlayer.playbackSpeed = 1f;
    }

    public void FastForwardBtn(){
        videoPlayer.playbackSpeed = 3f;
        if ((videoPlayer.frame) >= (long)(videoPlayer.frameCount - 1) && !videoPlayer.isLooping)
        {
            videoPlayer.playbackSpeed = 1f;
        }
    }



}
