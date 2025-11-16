using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    [SerializeField] private float lavaSpeedIncrease = 0.5f;
    [Tooltip("Reference to the RisingLava object (auto-found if null)")]
    [SerializeField] private RisingLava risingLava = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player crossed this checkpoint
        if (other.CompareTag("Player") && risingLava != null)
        {
            // Increase lava speed
            risingLava.IncreaseSpeed(lavaSpeedIncrease);
        }
    }
}
