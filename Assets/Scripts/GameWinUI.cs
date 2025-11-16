using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameWinUI : MonoBehaviour
{
    [SerializeField] private AudioClip winSfx = null;
    private AudioSource audioSource = null;

    public static GameWinUI Instance;

    public GameObject gameWinPanel;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleGameWin());
        }
    }

    private IEnumerator HandleGameWin()
    {
        if (winSfx != null && audioSource != null)
        {
            audioSource.PlayOneShot(winSfx);
        }
        // Pause game
        Time.timeScale = 0f;

        // Show game over UI
        gameWinPanel.SetActive(true);

        // Wait 5 seconds (real time, not affected by timeScale)
        yield return new WaitForSecondsRealtime(5f);

        // Resume time
        Time.timeScale = 1f;

        // Load main menu
        SceneManager.LoadScene(0);
    }
}
