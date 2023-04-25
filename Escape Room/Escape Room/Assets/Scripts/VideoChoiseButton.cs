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
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CheckVideoDone();
    }

    private void CheckVideoDone()
    {

        if ((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false))
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }


}
