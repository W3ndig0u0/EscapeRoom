using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{

    public GameObject optionsPanel;
    public GameObject LanguagesPanel;
    public Button startButton;
    public Button optionsButton;
    public Button languageButton;
    public Button quitButton;

    public void Start()
    {
        optionsPanel.SetActive(false);
        LanguagesPanel.SetActive(false);

    }


    public void OnClickedOptionsButton()
    {
        optionsPanel.SetActive(true);
        startButton.interactable = false;
        optionsButton.interactable = false;
        quitButton.interactable = false;
    }

    public void HideOptions()
    {
        Debug.Log(optionsPanel);
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
            startButton.interactable = true;
            optionsButton.interactable = true;
            quitButton.interactable = true;
        }

    }

    public void OnClickedLanguagesButton()
    {
        LanguagesPanel.SetActive(true);
    }
    public void HideLanguges()
    {
        if (LanguagesPanel != null)
        {
            LanguagesPanel.SetActive(false);
        }

    }

}