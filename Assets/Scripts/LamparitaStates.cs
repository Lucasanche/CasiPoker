using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamparitaStates : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] DialogueManager dialogueOption;
    [SerializeField] public string mood;
    [SerializeField] Animator door;
    [SerializeField] BoxCollider2D doorCollider;
    private bool lightbool = false;

    // Update is called once per frame
    void Update()
    {
        mood = dialogueOption.tags;
        if (!lightbool)
        {
            switch (mood)
            {
                case "happy":
                    animator.SetTrigger("Happy");
                    break;
                case "sad":
                    animator.SetTrigger("Sad");
                    break;
                case "angry":
                    animator.SetTrigger("Angry");
                    break;
                case "light":
                    animator.SetTrigger("Light");
                    door.SetTrigger("OpenDoor1");
                    doorCollider.enabled = false;
                    lightbool = true;
                    break;
            }
        } 
    }
}
