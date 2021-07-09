using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Rigidbody2D rb;
    Player player;
   bool isDestroyed = false;
    public Animator animator;
    public PolygonCollider2D pg;
    public AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.5f; 
   
    Vector3 enemyMovement = new Vector3(-0.01f, 0, 0);

    void Start()
    {
        //  rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
            pg = FindObjectOfType<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDestroyed == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                player.Die();
            }
            if (collision.gameObject.tag == "DirectionChanger")
            {
                enemyMovement.x *= -1f;

            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Die();

        }
    }

    private void Die()
    { 
        Destroy(gameObject, 0.5f);
        pg.enabled = false;
        isDestroyed = true;
        animator.SetBool("isDead", true);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSFXVolume);

    }
    
    void Update()
    {
        transform.Translate(enemyMovement);
    }
}
