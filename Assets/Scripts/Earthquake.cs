using UnityEngine;
using System.Collections;

public class Earthquake : MonoBehaviour
{
    [SerializeField] private float minShakeInterval = 3f;
    [SerializeField] private float maxShakeInterval = 8f;
    [SerializeField] private float shakeIntensity = 0.3f;
    [SerializeField] private float shakeDuration = 0.3f;

    [SerializeField] private FallingTrapSpawner trapSpawner = null;
    [SerializeField] private float earthquakeMinSpawnInterval = 0.3f;
    [SerializeField] private float earthquakeMaxSpawnInterval = 0.8f;

    private void Start()
    {
        // Auto-find FallingTrapSpawner if not assigned
        if (trapSpawner == null)
        {
            trapSpawner = FindObjectOfType<FallingTrapSpawner>();
        }

        ScheduleNextShake();
    }

    private void ScheduleNextShake()
    {
        float delay = Random.Range(minShakeInterval, maxShakeInterval);
        Invoke(nameof(TriggerShake), delay);
    }

    private void TriggerShake()
    {
        // Call camera shake if CameraShake exists
        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.Shake(shakeIntensity, shakeDuration);
        }

        // Increase trap spawn rate during the shake
        if (trapSpawner != null)
        {
            trapSpawner.SetTemporarySpawnRate(earthquakeMinSpawnInterval, earthquakeMaxSpawnInterval, shakeDuration);
        }

        // Schedule the next shake
        ScheduleNextShake();
    }
}
