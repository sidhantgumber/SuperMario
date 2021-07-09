using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float delayInDestroy;  // ek dam se destroy na ho block
    public AudioClip destroySFX;
    [SerializeField] [Range(0, 1)] float destroySFXVolume = 0.5f;


    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         Destroy(gameObject);

     }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject,delayInDestroy);
        AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position, destroySFXVolume);
    }
}
