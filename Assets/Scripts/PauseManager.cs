using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//If player clicks a button it will modify here
public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
   
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
                PauseGame();
            
        }
    }

    public void PauseGame(){
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame(){
        SceneManager.LoadScene("MainMenu");
    }
}
