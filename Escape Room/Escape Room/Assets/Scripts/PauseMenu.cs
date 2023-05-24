using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] public GameObject PauseMenuPanel;
    private VideoPlayer player;
    public GameObject hideShowGameButtons;
    public GameObject VideoPlayerObject;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    public void PauseGame()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        VideoPlayerObject.GetComponent<PlayNextVideo>().enabled = false;
    }

    public void ResumeGame()
    {
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        VideoPlayerObject.GetComponent<PlayNextVideo>().enabled = true;
    }

    public void PlayPauseVideo()
    {
        if (player.isPlaying == false)
        {
            player.Play();
        }
        else
        {
            player.Pause();
        }
    }

    public void ShowHideGameButtons()
    {
        if (hideShowGameButtons.activeInHierarchy == true)
        {
            hideShowGameButtons.SetActive(false);
        }

        else
        {
            hideShowGameButtons.SetActive(true);
        }

    }
 
}
