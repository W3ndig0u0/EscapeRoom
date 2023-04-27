using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayAnimationText : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private RectTransform rectTransform;

    void Start()
    {
        videoPlayer = FindFirstObjectByType<VideoPlayer>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(0, 71);

    }
    void Update()
    {
        CheckVideoDone();
    }

    private void CheckVideoDone()
    {

        if ((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false))
        {
            rectTransform.sizeDelta = new Vector2(420, 71);
            return;
        }
        rectTransform.sizeDelta = new Vector2(0, 71);
    }
}
