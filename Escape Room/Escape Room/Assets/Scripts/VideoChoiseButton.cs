using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class VideoChoiseButton : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Button btn2;

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
            return;
        }
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    public void RemoveButton() 
    {
        btn2.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void ActivateNewButton(GameObject btnParent)
    {
        btnParent.SetActive(true);
    }




}
