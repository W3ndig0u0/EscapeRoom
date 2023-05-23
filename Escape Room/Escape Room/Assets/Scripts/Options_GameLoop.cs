using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_GameLoop : MonoBehaviour
{

    public GameObject optionsPanel;
    public Button resumeButton;
    public Button mainMenuButton;
    public Button quitGameButton;
    public Button optionsButtton;

    public void Start()
    {
        optionsPanel.SetActive(false);
    }

    public void OnClickedOptionsButton()
    {
        optionsPanel.SetActive(true);
        resumeButton.interactable = false;
        optionsButtton.interactable = false;
        mainMenuButton.interactable = false;
        quitGameButton.interactable = false;
        

    }

    public void HideOptions()
    {
        Debug.Log(optionsPanel);
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
            resumeButton.interactable = true;
            optionsButtton.interactable = true;
            mainMenuButton.interactable = true;
            quitGameButton.interactable = true;
            

        }

    }

}