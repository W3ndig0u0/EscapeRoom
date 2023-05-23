using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public AudioSource audioSource;

    private void Start()
    {
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        button2.gameObject.SetActive(false);
    }


    private void OnDestroy()
    {
        button1.onClick.RemoveListener(OnButton1Click);
        button2.onClick.RemoveListener(OnButton2Click);
    }

    private void OnButton1Click()
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);

        audioSource.Stop();
    }

    private void OnButton2Click()
    {
        button2.gameObject.SetActive(false);
        button1.gameObject.SetActive(true);

        audioSource.Play();
    }
}