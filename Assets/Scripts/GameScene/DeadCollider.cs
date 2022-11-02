using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadCollider : MonoBehaviour
{
    public static bool isDead;

    private void Start()
    {
        isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDead = true;
            StartCoroutine(HighscoreSceneCoroutine());
        }
        
        if(collision.CompareTag("Plane"))
        {
            Destroy(collision, 1f);
        }
    }

    IEnumerator HighscoreSceneCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
