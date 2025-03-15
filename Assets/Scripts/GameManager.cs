using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerScore = 0;
    public int playerHealth = 3;
    public int timePassed = 0;
    private float startTime;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI healthText;
    private TextMeshProUGUI gameTimerText; 
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startTime = Time.timeSinceLevelLoad;
        FindUIElements();
        UpdateUI();
        UpdateGameTimer();
    }

    private void Update()
    {
        if (scoreText == null || healthText == null)
        {
            FindUIElements();
        }
        UpdateGameTimer();
    }


    private void FindUIElements()
    {
        GameObject scoreObj = GameObject.Find("ScoreText");
        GameObject healthObj = GameObject.Find("HealthText");
        GameObject timeObj = GameObject.Find("TimerText");

        if (scoreObj) scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
        if (healthObj) healthText = healthObj.GetComponent<TextMeshProUGUI>();
        UpdateUI();
        if (timeObj) gameTimerText = timeObj.GetComponent<TextMeshProUGUI>();
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
        timePassed = (int)(Time.timeSinceLevelLoad - startTime);
        int minutes = timePassed / 60;
        int seconds = timePassed % 60;
        gameTimerText.text = minutes + ":" + seconds.ToString("00");
    }

    public void RestartLevel()
    {
        // Reset all
        playerHealth = 3; 
        playerScore = 0;
        timePassed = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}