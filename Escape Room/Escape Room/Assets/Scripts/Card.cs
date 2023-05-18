using System;
using UnityEngine;

public class Card : MonoBehaviour
{
    public event Action<Card> OnCardClicked; // Event triggered when the card is clicked
    public bool IsMatched { get; private set; } // Indicates if the card is already matched

    public Sprite frontSprite; // Front sprite when the card is flipped
    public Sprite backSprite; // Back sprite when the card is not flipped

    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer component

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        // Trigger the OnCardClicked event
        Debug.Log("AAA");
        OnCardClicked?.Invoke(this);
    }

    public void Flip()
    {
        if (spriteRenderer.sprite == backSprite)
            spriteRenderer.sprite = frontSprite;
        else
            spriteRenderer.sprite = backSprite;
    }

    public bool IsMatch(Card otherCard)
    {
        return otherCard != null && otherCard.backSprite == backSprite;
    }


    public void Match()
    {
        IsMatched = true;
    }
}