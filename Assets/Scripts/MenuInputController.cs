using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputController : MonoBehaviour
{
    [SerializeField] ColorBlindnessFilter mainCamera; 

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame) mainCamera.FilterProtanopia();
        if (Keyboard.current.dKey.wasPressedThisFrame) mainCamera.FilterDeuteranopia();
        if (Keyboard.current.tKey.wasPressedThisFrame) mainCamera.FilterTritanopia();
        if (Keyboard.current.nKey.wasPressedThisFrame) mainCamera.FilterNormal();
    }
}
