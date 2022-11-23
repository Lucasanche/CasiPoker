using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TermometroStates : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] DialogueManager dialogueOption;
    [SerializeField] public string mood;
    [SerializeField] Animator HeatUp;
    [SerializeField] Animator PlayerState;
    [SerializeField] Animator Heladito1;
    [SerializeField] Animator Heladito2;
    [SerializeField] TilemapCollider2D FenceCollider;
    // Update is called once per frame
    void Update()
    {
        mood = dialogueOption.tags;
        switch (mood)
        {
            case "happy2":
                animator.SetTrigger("Heat");
                HeatUp.SetTrigger("Heat");
                PlayerState.SetTrigger("Melt");
                Heladito2.SetTrigger("Melt");
                Heladito1.SetTrigger("Melt");
                FenceCollider.enabled = false;
                break;
            case "bored":
                break;
            case "angry":
                break;
            case "light":
                break;
        }
    }
}
