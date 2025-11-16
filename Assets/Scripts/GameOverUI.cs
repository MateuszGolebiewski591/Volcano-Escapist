using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;

    public GameObject gameOverPanel;
    [SerializeField] GameObject uiText;

    private void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
    }

    public void Show()
    {
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0, 0);
        }
        uiText.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
