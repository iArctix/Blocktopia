using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject gameplayui;
    private bool isPaused = false;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            isPaused = !isPaused;

           
            if (isPaused)
            {
                
                Time.timeScale = 0f; 
                pauseMenuPanel.SetActive(true); 
                gameplayui.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                
                Time.timeScale = 1f;
                pauseMenuPanel.SetActive(false);
                gameplayui.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        gameplayui.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
    public void quit()
    {
        Application.Quit();
    }


}
