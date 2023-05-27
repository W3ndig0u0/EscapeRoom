using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        PlayAnimationText();
    }


    private void PlayAnimationText()
    {
        Debug.Log(animator);
        animator.Play("Animation");
        animator.SetTrigger("TextAnimation");
    }
}
