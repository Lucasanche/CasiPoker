using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire : MonoBehaviour
{
    [SerializeField] Animator player;
    [SerializeField] TilemapCollider2D SpikesCollider;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.SetTrigger("Vapor");
            SpikesCollider.enabled = false;
        }
    }
}
