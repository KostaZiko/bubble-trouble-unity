using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject pausePanel;

    [Header("Timer")]
    public TMP_Text timerText;
    public float timeLimit = 45f;

    [Header("Level Display")]
    public GameObject levelPanel;
    public TMP_Text levelText;

    private float timeRemaining;
    private bool timerRunning = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        FindReferences(); 
        gameOverPanel?.SetActive(false);
        winPanel?.SetActive(false);
        levelPanel?.SetActive(false);
        timeRemaining = timeLimit;
        timerRunning = true;
    }

    void FindReferences()
    {
        if (levelPanel == null)
            levelPanel = GameObject.Find("LevelPanel");

        if (levelText == null)
            levelText = GameObject.Find("LevelText")?.GetComponent<TMP_Text>();

        if (timerText == null)
            timerText = GameObject.Find("TimerText")?.GetComponent<TMP_Text>();

        if (gameOverPanel == null)
            gameOverPanel = GameObject.Find("GameOverPanel");

        if (winPanel == null)
            winPanel = GameObject.Find("WinPanel");

        if (pausePanel == null)
            pausePanel = GameObject.Find("PausePanel");
    }

   
    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        FindReferences(); 
        gameOverPanel?.SetActive(false);
        winPanel?.SetActive(false);
        levelPanel?.SetActive(false);
        timeRemaining = timeLimit;
        timerRunning = true;
    }

    void Update()
    {
        if (!timerRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            timerRunning = false;
            GameManager.Instance.PlayerDied();
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        if (timerText == null) return;
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = $"{seconds}";

        if (seconds <= 10)
            timerText.color = Color.red;
        else
            timerText.color = Color.white;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void ResetTimerForNextLevel()
    {
        timeRemaining = timeLimit + 15f;
        timerRunning = true;
    }

    public void ShowLevelDisplay(int level)
    {
        if (levelPanel == null || levelText == null) return;
        levelText.text = "Level " + level;
        levelPanel.SetActive(true);

    }

 

    public void ShowGameOver()
    {
        timerRunning = false;
        gameOverPanel?.SetActive(true);
    }

    public void ShowWin()
    {
        timerRunning = false;
        winPanel?.SetActive(true);
    }

    public void ShowPauseMenu(bool show)
    {
        pausePanel?.SetActive(show);
        if (show) timerRunning = false;
        else timerRunning = true;
    }
}