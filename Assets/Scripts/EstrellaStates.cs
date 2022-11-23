using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellaStates : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] DialogueManager dialogueOption;
    [SerializeField] public string mood;
    [SerializeField] BoxCollider2D starCollider;

    // Update is called once per frame
    void Update()
    {
        mood = dialogueOption.tags;
        switch (mood)
        {
            case "calm":
                animator.SetTrigger("Calm");
                starCollider.enabled = false;
                break;
            case "angry":
                break;
            case "euphoric":
                break;
            case "light":
                break;
        }
    }
}
