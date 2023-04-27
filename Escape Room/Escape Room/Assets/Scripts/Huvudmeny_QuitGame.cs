using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Huvudmeny_QuitGame : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    public void QuitGame() {
        Application.Quit();
        audioSource.PlayOneShot(audioClip);
    }
}
