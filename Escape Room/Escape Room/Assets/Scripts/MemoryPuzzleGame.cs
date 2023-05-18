    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MemoryPuzzleGame : MonoBehaviour
    {
        public Card[] cards; // Array of all cards in the game
        private Card previousCard; // Previously flipped card
        private int score; // Player's score

        private void Start()
        {
            // Shuffle the cards
            ShuffleCards();

            // Initialize variables
            previousCard = null;
            score = 0;

            // Attach click event handlers to each card
            foreach (Card card in cards)
            {
                card.OnCardClicked += CardClicked;
            }
        }

        private void ShuffleCards()
        {
            // Fisher-Yates shuffle algorithm
            for (int i = cards.Length - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }

private void CardClicked(Card clickedCard)
{
    if (clickedCard.IsMatched)
        return;

    clickedCard.Flip();

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
    }
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
        yield return new WaitForSeconds(0.2f);

        card1.Flip();
        card2.Flip();
    }
}