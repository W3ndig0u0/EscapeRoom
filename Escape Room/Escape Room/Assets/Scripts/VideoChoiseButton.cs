using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VideoChoiseButton : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Button btn2;
    public bool key;

    public GameObject VideoPlayerObject;
    public VideoClip NewVid;

    void Start()
    {
        videoPlayer = FindFirstObjectByType<VideoPlayer>();
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        
        PlayerPrefs.SetInt("HasKey", key ? 1 : 0);
        PlayerPrefs.Save();

    }

    void Update()
    {
        CheckVideoDone();
    }

    private void CheckVideoDone()
    {
        if (videoPlayer.isLooping == true)
        //((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false)) 
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

    public void ShowStoryboard(GameObject storyBoardImg)
    {
        storyBoardImg.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TakeKey()
    {
        key = true;
        Debug.Log(key);
        PlayerPrefs.SetInt("HasKey", key ? 1 : 0);
        PlayerPrefs.Save();
    }



    public void ChangeLoopingKlip()
    {
        VideoPlayerObject.GetComponent<PlayNextVideo>().NewLoopingClip = NewVid;
    }
    
}
