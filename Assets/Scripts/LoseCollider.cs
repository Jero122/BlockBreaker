using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int ballCount = FindObjectsOfType<Ball>().Length;
        if (ballCount == 1)
        {
            SceneManager.LoadScene("Game Over");
        }
       else
        {
            Destroy(collision.gameObject);
        }
    }
}
