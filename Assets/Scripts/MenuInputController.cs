using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuInputController : MonoBehaviour
{
    [SerializeField] ColorBlindnessFilter mainCamera; 
    [SerializeField] Disablable mainMenu;
    [SerializeField] Disablable panel;
    private int state = 0; //0-7
    

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

    public void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            if (gamepad.dpad.down.wasPressedThisFrame)
            {
                if(state == 2) state = 0;
                else if (state == 7) state = 3;
                else state++;
            }
            if (gamepad.dpad.up.wasPressedThisFrame)
            {
                if (state == 0) state = 2;
                else if (state == 3) state = 7;
                else state--;
            }
            if (gamepad.dpad.right.wasPressedThisFrame)
            {
                if (state == 0) PlayGame();
                if (state == 1)// pull up settings
                {
                    mainMenu.Disable();
                    panel.Enable();
                    state = 3;
                } 
                if (state == 2); QuitGame();
                if (state == 3) Normal();
                if (state == 4) Protanopia();
                if (state == 5) Deuteranopia();
                if (state == 6) Tritanopia();
                if (state == 7)
                {
                    mainMenu.Enable();
                    panel.Disable();
                    state = 1;
                }
            }
        }
    }
}
