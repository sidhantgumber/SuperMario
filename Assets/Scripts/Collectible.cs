using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public GameObject coin;
    Coin coins;
    public AudioClip coinSFX;
    [SerializeField] [Range(0, 1)] float coinSFXVolume = 0.5f;







    public float delayInBlockDestroy; // ek dam se na toote block

    private void Start()
    {
        coins = FindObjectOfType<Coin>();
    }
  
    private void SpawnCoins()
    {

        GameObject coinClone = Instantiate(coin, transform.position, Quaternion.identity);
        Destroy(coinClone, 0.4f);
    


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, delayInBlockDestroy);
        SpawnCoins();
        AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position, coinSFXVolume);




    }


}
