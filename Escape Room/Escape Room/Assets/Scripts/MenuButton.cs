using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public Languages languages;
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        //audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + languages.LevelManager());
    }

    public void Quit()
    {
        //audioSource.Play();
        Application.Quit();
    }
}