using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MemoryPuzzleGame : MonoBehaviour
{
    public Card[] cards; // Array of all cards in the game
    private Card previousCard; // Previously flipped card
    private int score; // Player's score
    private bool won;
    public GameObject timerSlider;
    private Animator animator;
    private bool isInputEnabled = true;

    public GameObject memoryGame;
    public GameObject fastForwardBtn;
    public VideoClip clip;
    public VideoChoise videoChoise;
    public GameObject btnParent;
    public AudioClip memoryAudio;
    public AudioClip pairFound;
    public AudioClip defaultBgMusic;
    public MusicController MusicController;


    private void Start()
    {
        // Initialize variables
        previousCard = null;
        score = 0;
        // Attach click event handlers to each card
        foreach (Card card in cards)
        {
            card.OnCardClicked += CardClicked;
        }
    }

    private void PlayPairFound()
    {
        GameObject audioObj = new GameObject("TempAudioSource");
        AudioSource tempAudioSource = audioObj.AddComponent<AudioSource>();

        tempAudioSource.clip = pairFound;
        tempAudioSource.Play();

        Destroy(tempAudioSource, pairFound.length);
        Destroy(audioObj, pairFound.length);
    }

private void CardClicked(Card clickedCard)
{

    if (!isInputEnabled || clickedCard.IsMatched || clickedCard == previousCard)
    {
        return;
    }
    
    clickedCard.FlipAnimation();
    
    if (previousCard == null)
    {
        previousCard = clickedCard;
    }
    else
    {
        if (previousCard.IsMatch(clickedCard))
        {
            score++;
            previousCard.Match();
            clickedCard.Match();
            PlayPairFound();
            StartCoroutine(RemoveMatchedPair(previousCard, clickedCard));
        }
        else
        {
            StartCoroutine(FlipCardsBack(previousCard, clickedCard));
        }

        previousCard = null;
    }

    if (score == cards.Length / 2)
    {
        StartCoroutine(GameIsWon());
        timerSlider.SetActive(false);
    }

    // Disable input temporarily
    isInputEnabled = false;
    StartCoroutine(EnableInputAfterDelay(0.5f)); // Adjust the delay as needed
}

    private IEnumerator EnableInputAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isInputEnabled = true;
    }

    private IEnumerator RemoveMatchedPair(Card card1, Card card2)
    {
        yield return new WaitForSeconds(0.5f);

        card1.gameObject.SetActive(false);
        card2.gameObject.SetActive(false);

        Debug.Log(score);
    }


    private IEnumerator FlipCardsBack(Card card1, Card card2)
    {
        yield return new WaitForSeconds(0.3f);

        card1.FlipBackAnimation();
        card2.FlipBackAnimation();
    }

    public IEnumerator GameIsWon()
    {
        yield return new WaitForSeconds(0.35f);

        if (cards[0] != null)
        {
            foreach (Card card in cards)
            {
                card.gameObject.SetActive(false);
            }
        }

        won = true;
        videoChoise.ChangeClipAuto(clip);
        videoChoise.ChangeClip(clip);
        btnParent.SetActive(true);
        fastForwardBtn.SetActive(true);
        MusicController.ReplaceAudioSource(defaultBgMusic);
    }
    public void GameIsOver()
    {
        if (cards[0] != null)
        {
            foreach (Card card in cards)
            {
                card.gameObject.SetActive(false);
            }
        }

        btnParent.SetActive(true);
        fastForwardBtn.SetActive(true);
        MusicController.ReplaceAudioSource(defaultBgMusic);
    }
    public void Restart()
    {
        if (won)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                Card card = cards[i];
             
                for (int j = 1; j < cards.Length; j++)
                {
                    card.IsMatch(cards[i]);

                }

                card.gameObject.SetActive(true);
                card.GetComponent();
                card.Flip();
            }
        }

        timerSlider.SetActive(true);

        previousCard = null;
        won = false;
        score = 0;
    }


    public void Activate()
    {
        if (won)
        {
            return;
        }
        memoryGame.SetActive(true);
        fastForwardBtn.SetActive(false);
        MusicController.ReplaceAudioSource(memoryAudio);
    }
}