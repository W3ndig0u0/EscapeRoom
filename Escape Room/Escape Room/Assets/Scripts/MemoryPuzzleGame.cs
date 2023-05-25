    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class MemoryPuzzleGame : MonoBehaviour
{
    public Card[] cards; // Array of all cards in the game
    private Card previousCard; // Previously flipped card
    private int score; // Player's score
    public GameObject timerSlider;
    private Animator animator;
    private bool isInputEnabled = true;

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
        Debug.Log("All pairs matched.");
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
        yield return new WaitForSeconds(0.2f);

        Destroy(card1.gameObject);
        Destroy(card2.gameObject);
        Debug.Log(score);
    }


    private IEnumerator FlipCardsBack(Card card1, Card card2)
    {
        yield return new WaitForSeconds(0.3f);

        card1.FlipBackAnimation();
        card2.FlipBackAnimation();
    }

    public void RemoveKey(){
        foreach(Card card in cards){
            Destroy(card.gameObject);
        }
    }
}