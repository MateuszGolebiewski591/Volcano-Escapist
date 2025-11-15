using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class StaticLava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleGameOver());
        }
    }

    private IEnumerator HandleGameOver()
    {
        // Pause game
        Time.timeScale = 0f;

        // Show game over UI
        GameOverUI.Instance.Show();

        // Wait 5 seconds (real time, not affected by timeScale)
        yield return new WaitForSecondsRealtime(5f);

        // Resume time
        Time.timeScale = 1f;

        // Load main menu
        SceneManager.LoadScene(0);
    }
}
