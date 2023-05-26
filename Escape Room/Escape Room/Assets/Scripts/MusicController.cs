using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public AudioSource audioSource;

    private bool isEnabled = true;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MusicEnabled"))
        {
            isEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        }
        else
        {
            isEnabled = true;
        }
    
        SetMusicEnabled(isEnabled);
    }

    private void Start()
    {
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
    }

    private void OnDestroy()
    {
        button1.onClick.RemoveListener(OnButton1Click);
        button2.onClick.RemoveListener(OnButton2Click);

    }

    private void OnButton1Click()
    {
        SetMusicEnabled(false);
    }

    private void OnButton2Click()
    {
        SetMusicEnabled(true);
    }

    private void SetMusicEnabled(bool enabled)
    {
        isEnabled = enabled;
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
        PlayerPrefs.Save();


        button1.gameObject.SetActive(enabled);
        button2.gameObject.SetActive(!enabled);

        audioSource.enabled = enabled;

        if (enabled){
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void ReplaceAudioSource(AudioClip newAudioClip)
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.clip = newAudioClip;

            if (isEnabled)
                audioSource.Play();
        }
    }

}
