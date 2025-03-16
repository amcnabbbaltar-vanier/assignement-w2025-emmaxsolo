using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerScore = 0;
    public int playerHealth = 3;
    public int timePassed = 0;

    public int checkpointScore = 0;
    public int checkpointTime = 0;

    private float globalStartTime;

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI healthText;
    private TextMeshProUGUI gameTimerText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            globalStartTime = Time.time;
            SceneManager.sceneLoaded += OnSceneLoaded; // Hook scene load
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Automatically find HUD texts once when scene is loaded
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("HealthText")?.GetComponent<TextMeshProUGUI>();
        gameTimerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();

        UpdateUI();
        UpdateGameTimer();
    }

    private void Update()
    {
        UpdateGameTimer();
    }

    public void AddScore(int amount)
    {
        playerScore += amount;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UpdateUI();

        if (playerHealth <= 0)
        {
            RestartLevel();
        }
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + playerScore;

        if (healthText != null)
            healthText.text = "Health: " + playerHealth;
    }

    private void UpdateGameTimer()
    {
        timePassed = (int)(Time.time - globalStartTime);
        int minutes = timePassed / 60;
        int seconds = timePassed % 60;

        if (gameTimerText != null)
            gameTimerText.text = minutes + ":" + seconds.ToString("00");
    }

    public void RestartLevel()
    {
        playerHealth = 3;
        playerScore = checkpointScore;
        timePassed = checkpointTime;
        globalStartTime = Time.time - checkpointTime;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel(int index)
    {
        checkpointScore = playerScore;
        checkpointTime = timePassed;
        SceneManager.LoadScene(index);
    }

    public void QuitToMainMenu()
    {
        playerScore = 0;
        playerHealth = 3;
        timePassed = 0;
        checkpointScore = 0;
        checkpointTime = 0;

        SceneManager.LoadScene("MainMenu");
    }
}
