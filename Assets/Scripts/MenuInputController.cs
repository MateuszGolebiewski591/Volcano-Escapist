using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInputController : MonoBehaviour
{
    [SerializeField] ColorBlindnessFilter mainCamera; 

    

    public void Normal()
    {
        mainCamera.FilterNormal();
    }

    public void Protanopia()
    {
        mainCamera.FilterProtanopia();
    }

    public void Deuteranopia()
    {
        mainCamera.FilterDeuteranopia();
    }

    public void Tritanopia()
    {
        mainCamera.FilterTritanopia();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
