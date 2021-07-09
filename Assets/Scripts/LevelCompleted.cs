using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCompleted : MonoBehaviour
{
    public AudioClip victoryMusic;
    public ParticleSystem fireworks;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(loadWinScene());
        Instantiate(fireworks, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(victoryMusic, Camera.main.transform.position, 1f);
    }

    private IEnumerator loadWinScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(2);
    }

}
