using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    [SerializeField] private float lavaSpeedIncrease = 0.5f;
    [SerializeField] private RisingLava risingLava = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Checkpoint reached! Increasing lava speed.");
        // Check if the player crossed this checkpoint
        if (other.CompareTag("Player") && risingLava != null)
        {
            Debug.Log("Checkpoint reached! Increasing lava speed.");
            // Increase lava speed
            risingLava.IncreaseSpeed(lavaSpeedIncrease);
        }
    }
}
