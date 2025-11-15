using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    public void PlayGame()
    {
        SceneManager. LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
