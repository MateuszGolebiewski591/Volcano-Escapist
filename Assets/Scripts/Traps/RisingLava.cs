using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class RisingLava : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] private AudioClip gameoverSfx = null;
    private AudioSource audioSource = null;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    /// <summary>
    /// Increases the lava movement speed by the given amount.
    /// </summary>
    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleGameOver());
        }
    }

    private IEnumerator HandleGameOver()
    {
        if (gameoverSfx != null && audioSource != null)
        {
            audioSource.PlayOneShot(gameoverSfx);
        }
        
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
