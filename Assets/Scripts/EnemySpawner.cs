using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //  public List<Transform> SpawnPoints;
    public Transform spawnPoint;
    public GameObject enemyPrefab;
    
  //  public Player player;

    // Start is called before the first frame update
    void Start()
    {
      //  player = FindObjectOfType<Player>();
       

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnEnemy();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, Quaternion.identity);
     
    }

}
