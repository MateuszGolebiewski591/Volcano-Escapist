using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;

    public GameObject gameOverPanel;
    [SerializeField] GameObject uiText;
    [SerializeField] RumbleController rumbleController;

    private void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
    }

    public void Show()
    {
        rumbleController.gameover = true;
        uiText.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
