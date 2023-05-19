using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private Image targetButton;

    public void ChangeSprite()
    {
        if (targetButton.sprite == buttonSprites[0])
        {
            targetButton.sprite = buttonSprites[1];
            return;
        }
        targetButton.sprite = buttonSprites[0];
    }   

    void Start()
    {
        videoPlayer = FindFirstObjectByType<VideoPlayer>();
        videoPlayer.playbackSpeed = 1f;
    }

    public void FastForwardBtn(){
        
        if (videoPlayer.playbackSpeed == 1f)
        {
            videoPlayer.playbackSpeed = 3f;
        }

        else if (videoPlayer.playbackSpeed == 3f)
        {
            videoPlayer.playbackSpeed = 1f;
        }

        /*videoPlayer.playbackSpeed = 3f;
        if ((videoPlayer.frame) >= (long)(videoPlayer.frameCount - 1) && !videoPlayer.isLooping)
        {
            videoPlayer.playbackSpeed = 1f;
        }*/

    }



}
