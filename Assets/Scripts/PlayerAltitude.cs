using UnityEngine;
using TMPro;

public class PlayerAltitude : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI altitudeText;
    [SerializeField] private Transform player;
    [SerializeField] private float referenceY = 0f; // e.g., spawn height or ground level

    void Update()
    {
        if (player != null && altitudeText != null)
        {
            float altitude = player.position.y - referenceY;
            altitudeText.text = $"Current Altitude: {altitude:F1}m";
        }
    }
}
