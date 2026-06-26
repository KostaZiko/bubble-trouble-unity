using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public BubbleSpawner bubbleSpawner;

    private int currentLevel = 1;
    private const int maxLevel = 3;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (bubbleSpawner == null)
            bubbleSpawner = FindObjectOfType<BubbleSpawner>();

        bubbleSpawner.SpawnBubbles(currentLevel);
        StartCoroutine(ShowLevelDelayed(currentLevel)); 
    }

    IEnumerator ShowLevelDelayed(int level)
    {
        yield return new WaitForSeconds(0.1f);
        UIManager.Instance?.ShowLevelDisplay(level);
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        UIManager.Instance.ShowGameOver();
    }

    public void CheckWin()
    {
        BubbleController[] bubbles = FindObjectsByType<BubbleController>(FindObjectsSortMode.None);

        if (bubbles.Length == 0)
        {
            currentLevel++;

            if (currentLevel <= maxLevel)
            {
                bubbleSpawner.SpawnBubbles(currentLevel);
                UIManager.Instance.ResetTimerForNextLevel();
                UIManager.Instance.ShowLevelDisplay(currentLevel); 
            }
            else
            {
                Time.timeScale = 0f;
                UIManager.Instance.ShowWin();
            }
        }
    }

    public void RestartGame()
    {
        AudioManager.Instance?.PlayButtonClick();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        AudioManager.Instance?.PlayButtonClick();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        UIManager.Instance.ShowPauseMenu(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        UIManager.Instance.ShowPauseMenu(false);
    }
}