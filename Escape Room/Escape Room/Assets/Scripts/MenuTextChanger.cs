using UnityEngine;
using UnityEngine.UI;

public class MenuTextChanger : MonoBehaviour
{

    public Languages languages;

    //! languagePaneL
    public Text languagePanelText;
    private string languagePanelTextSv = "Språk";
    private string languagePanelTextEng = "Languages";

    public Text CloseButtonText;
    private string CloseButtonTextSv = "Stäng";
    private string CloseButtonTextEng = "Close";


    //! OPTIONS
    public Text OptionPanelText;
    private string OptionPanelTextSv = "Alternativ";
    private string OptionPanelTextEng = "Option";

    public Text languageButtonText;
    private string languageButtonTexttSv = "Språk";
    private string languageButtonTextEng = "Languages";


    public Text CloseButtonText2;
    private string CloseButtonTextSv2 = "Stäng";
    private string CloseButtonTextEng2 = "Close";

    public Text MusicButtonText;
    private string MusicButtonTextSv = "Musik";
    private string MusicButtonTextEng = "Music";

    //!HUVUDMENYN
    public Text StartButtonText;
    private string StartButtonTextSv = "Starta";
    private string StartButtonTextEng = "Start";


    public Text OptionButtonText;
    private string OptionButtonTextSv = "Alternativ";
    private string OptionButtonTextEng = "Option";

    public Text QuitButtonText;
    private string QuitButtonTextSv = "Avsluta";
    private string QuitButtonTextEng = "Quit";

    private void Start()
    {
        if (languages.isEnglish) {
            EngMenuText();
            return;
        }

        SvMenuText();
    }

    public void SvMenuText()
    {
        languagePanelText.text = languagePanelTextSv;
        CloseButtonText.text = CloseButtonTextSv;

        OptionPanelText.text = OptionPanelTextSv;
        languageButtonText.text = languageButtonTexttSv;
        CloseButtonText2.text = CloseButtonTextSv2;
        MusicButtonText.text = MusicButtonTextSv;

        StartButtonText.text = StartButtonTextSv;
        OptionButtonText.text = OptionButtonTextSv;
        QuitButtonText.text = QuitButtonTextSv;
    }

    public void EngMenuText()
    {
        languagePanelText.text = languagePanelTextEng;
        CloseButtonText.text = CloseButtonTextEng;
        
        OptionPanelText.text = OptionPanelTextEng;
        languageButtonText.text = languageButtonTextEng;
        CloseButtonText2.text = CloseButtonTextEng2;
        MusicButtonText.text = MusicButtonTextEng;

        StartButtonText.text = StartButtonTextEng;
        OptionButtonText.text = OptionButtonTextEng;
        QuitButtonText.text = QuitButtonTextEng;
    }
}