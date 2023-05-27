using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Languages : MonoBehaviour
{
    public bool isEnglish;

    public Button swedishBtn;
    public Button englishBtn;
    [SerializeField] private Sprite[] buttonSprites;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("isEnglish"))
        {
            isEnglish = PlayerPrefs.GetInt("isEnglish", 1) == 1;
        }
        else
        {
            isEnglish = true;
        }
    }

    private void Start()
    {
        if (isEnglish)
        {
            ChangeSprite(englishBtn);
            return;
        }

        ChangeSprite(swedishBtn);
    }

    public void ChangeSprite(Button targetButton)
    {
        if (targetButton == swedishBtn)
        {
            swedishBtn.image.sprite = buttonSprites[1];
            englishBtn.image.sprite = buttonSprites[0];
        }

        else if (targetButton == englishBtn)
        {
            englishBtn.image.sprite = buttonSprites[1];
            swedishBtn.image.sprite = buttonSprites[0];
        }
    }


    public void Swedish()
    {
        isEnglish = false;
        PlayerPrefs.SetInt("isEnglish", isEnglish ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void English()
    {
        isEnglish = true;
        PlayerPrefs.SetInt("isEnglish", isEnglish ? 1 : 0);
        PlayerPrefs.Save();
    }

    public int LevelManager()
    {
        if (isEnglish)
        {
            Debug.Log("Eng");
            return 1;
        }

        Debug.Log("Sv");
        return 2;

    }
}
