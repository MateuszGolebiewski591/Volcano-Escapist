using UnityEngine;

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
        uiText.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
