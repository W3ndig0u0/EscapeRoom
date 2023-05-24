using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayNextVideo : MonoBehaviour
{

    private VideoPlayer videoPlayer;

    public VideoClip NewLoopingClip;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if ((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false))
        {
            videoPlayer.clip = NewLoopingClip;
            videoPlayer.Play();
            GetComponent<VideoPlayer>().isLooping = true;
        }

    }
}
