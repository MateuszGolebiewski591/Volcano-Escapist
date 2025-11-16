using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    [SerializeField] private float lavaSpeedIncrease = 0.5f;
    [SerializeField] private RisingLava risingLava;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player crossed this checkpoint
        if (other.CompareTag("Player") && !triggered)
        {
            // Increase lava speed
            risingLava.IncreaseSpeed(lavaSpeedIncrease);
            triggered = true;
        }
    }
}
