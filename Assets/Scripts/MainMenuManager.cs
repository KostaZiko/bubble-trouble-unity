using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject howToPlayPanel;
    public GameObject optionsPanel;

    void Start()
    {
        mainPanel?.SetActive(true);
        howToPlayPanel?.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnPlayPressed()
    {
        AudioManager.Instance?.PlayButtonClick();
        SceneManager.LoadScene("Game");
    }

    public void OnOptionsPressed()
    {
        AudioManager.Instance?.PlayButtonClick();
        mainPanel?.SetActive(false);
        optionsPanel?.SetActive(true);
    }

    public void OnBackFromOptionsPressed()
    {
        AudioManager.Instance?.PlayButtonClick();
        optionsPanel?.SetActive(false);
        mainPanel?.SetActive(true);
    }

    public void OnBackPressed()
    {
        AudioManager.Instance?.PlayButtonClick();
        mainPanel?.SetActive(true);
        howToPlayPanel?.SetActive(false);
    }

    public void OnQuitPressed()
    {
        AudioManager.Instance?.PlayButtonClick();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}