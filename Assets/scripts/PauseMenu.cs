using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenuPanel;

   
    private bool isPaused = false;

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    
    public void Resume()
    {
        pauseMenuPanel.SetActive(false); 
        Time.timeScale = 1f;            
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    
    void Pause()
    {
        pauseMenuPanel.SetActive(true);  
        Time.timeScale = 0f;             
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;   
        Cursor.visible = true;
    }

  
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(2);
    }
}