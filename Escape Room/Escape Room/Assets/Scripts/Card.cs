using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public event Action<Card> OnCardClicked; // Event triggered when the card is clicked
    public bool IsMatched { get; private set; } // Indicates if the card is already matched

    public Sprite frontSprite; // Front sprite when the card is flipped
    public Sprite backSprite; // Back sprite when the card is not flipped

    private Image spriteRenderer; // Reference to the sprite renderer component

    private Animator animator; // Reference to the Animator component

    public AudioSource audio;

    private void Start()
    {
        GetComponent();
    }

    public void GetComponent()
    {
        spriteRenderer = GetComponent<Image>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    

    public void OnMouseDown()
    {
        OnCardClicked?.Invoke(this);
    }

    public void Flip()
    {

        if (spriteRenderer.sprite == backSprite)
            spriteRenderer.sprite = frontSprite;
        else
            spriteRenderer.sprite = backSprite;
    }

    public void SoundPlay()
    {
        audio.Play();

    }

    public void FlipAnimation()
    {
        if (animator != null && !animator.GetBool("Flip"))
        {
            animator.SetBool("Flip", true);
            animator.SetBool("FlipBack", false);
            StartCoroutine(StopFlipAnimation());
        }
    }

    public void FlipBackAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("Flip", false);
            animator.SetBool("FlipBack", true);
            StartCoroutine(StopFlipAnimation());
        }
    }

    
    private IEnumerator StopFlipAnimation()
    {
        yield return new WaitForSeconds(0.2f);

        if (animator != null)
        {
            animator.SetBool("Flip", false);
            animator.SetBool("FlipBack", false);
        }
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