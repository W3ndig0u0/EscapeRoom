using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Huvudmeny_StartGame : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    public void StartGame() {

        SceneManager.LoadScene(1);
        audioSource.PlayOneShot(audioClip);

    }

}
