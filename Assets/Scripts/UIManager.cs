using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject winPanel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        gameOverPanel?.SetActive(false);
        winPanel?.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel?.SetActive(true);
    }

    public void ShowWin()
    {
        winPanel?.SetActive(true);
    }
}