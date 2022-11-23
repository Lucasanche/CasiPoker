using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] Ice solid;
    [SerializeField] Animator animator;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && solid.solid)
        {
            animator.SetTrigger("Press");
        }
    }
}
