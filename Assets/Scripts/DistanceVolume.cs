using UnityEngine;

public class DistanceVolume : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 20f;
    public float minDistance = 2f;

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
        Debug.Log("Distance: " + distance);
        Debug.Log("Distance to player: " + distance/maxDistance);
        float volume = 1 - distance / maxDistance;
        audioSource.volume = volume;
    }
}