using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator changeStates;
    [SerializeField] BoxCollider2D player;
    [SerializeField] BoxCollider2D fire;
    [SerializeField] BoxCollider2D ice;
    [SerializeField] Transform rotation;
    [SerializeField] TextMeshProUGUI text;
    private Vector2 moveDirection;
    private bool arrowSign = false;
    private bool spaceSign = false;
    float fade = 0.005f;
    // Update is called once per frame
    private void Update()
    {
        if (DialogueManager.instance.dialogueIsPlaying)
        {
            return;
        }
        ProcessInputs();
        if (arrowSign)
        {
            DeleteArrowSign();
        }
        else if (spaceSign && text.enabled)
        {
            StartCoroutine(DeleteSpaceSign());
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX > 0)
        {
            rotation.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveX < 0)
        {
            rotation.localScale = new Vector3(1, 1, 0);
        }
        if (moveX != 0 || moveY != 0)
        {
            if (!spaceSign)
            {
                arrowSign = true;
            }
            changeStates.SetTrigger("LiquidMove");
        }
        else
        {
            changeStates.SetTrigger("LiquidIdle");
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void DeleteArrowSign()
    {
        text.alpha -= fade;
        
        if(text.alpha <= 0)
        {
            text.alpha = 1;
            text.text = "PRESIONE LA BARRA ESPACIADORA PARA INICIAR LA CONVERSACIÓN";
            arrowSign = false;
            spaceSign = true;
        }
    }
    IEnumerator DeleteSpaceSign()
    {
        yield return new WaitForSeconds(1.5f);
        text.alpha -= fade; ;
        if(text.alpha <= 0)
        {
            text.enabled = false;
        }
    }
}
