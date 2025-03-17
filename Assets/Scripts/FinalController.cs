using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  

/*Controller to display the end of game stats*/
public class FinalController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalTimeText;

    public GameObject finalPanel;

    void Start()
    {
        finalPanel.SetActive(true);
        if (GameManager.Instance)
        {
            scoreText.text = "Final Score: " + GameManager.Instance.playerScore.ToString();
            
            int minutes = GameManager.Instance.timePassed / 60;
            int seconds = GameManager.Instance.timePassed % 60;
            finalTimeText.text = "Final Time: " + minutes + ":" + seconds.ToString("00");
        }
    }

    public void QuitGame()
    {
         SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
         if (GameManager.Instance)
        {
            //reset
            GameManager.Instance.playerScore = 0;
            GameManager.Instance.playerHealth = 3;
            GameManager.Instance.timePassed = 0;
            GameManager.Instance.checkpointScore = 0;
            GameManager.Instance.checkpointTime = 0;
            GameManager.Instance.globalStartTime = Time.time;
        }
        SceneManager.LoadScene("Level1");

    }
}
