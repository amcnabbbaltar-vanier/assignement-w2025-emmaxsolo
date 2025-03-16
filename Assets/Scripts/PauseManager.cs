using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject healthScorePanel;
    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        healthScorePanel.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        healthScorePanel.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitToMainMenu();
    }

    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }
}
