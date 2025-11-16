using UnityEngine;
using UnityEngine.InputSystem;

public class DistanceVolume : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 15f;
    private bool gameover = false;
    [SerializeField] private float intensity = 0.1f;
    [SerializeField] RumbleController rumbleController;

    [SerializeField] private AudioClip sfx = null;
    private AudioSource audioSource;
    public bool loop = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sfx;
        audioSource.loop = loop;
        audioSource.spatialBlend = 0f;
        audioSource.Play();
    }

    void Update()
    {
        float distance = player.position.y - transform.position.y;
        float volume = 1 - distance / maxDistance;
        audioSource.volume = volume;

        if (distance < maxDistance) {
            float rumble = Mathf.Pow(volume, 2f) * intensity;
            rumbleController.SetRumble(rumble, rumble);
        }

    }
}