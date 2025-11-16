using UnityEngine;
using TMPro;

public class LavaAltitude : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private RisingLava risingLava;

    void Update()
    {
        if (risingLava != null && distanceText != null)
        {
            float distance = risingLava.transform.position.y;
            distanceText.text = $"Lava Altitude: {distance:F1}m";
        }
    }
}
