using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ice : MonoBehaviour
{
    [SerializeField] Animator player;
    [SerializeField] TilemapCollider2D SpikesCollider;
    public bool solid = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.SetTrigger("Solidify");
            SpikesCollider.enabled = true;
            solid = true;
        }
    }
}
