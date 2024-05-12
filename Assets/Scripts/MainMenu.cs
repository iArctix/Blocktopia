using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startindicator;
    public GameObject endindicator;

    private void Start()
    {
        startindicator.SetActive(false);
        endindicator.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }

    public void Startbut()
    {
        SceneManager.LoadScene(1);
        
    }
    public void quit()
    {
        Application.Quit();
        
    }

    public void startenter()
    {
        startindicator.SetActive(true);
        endindicator.SetActive(false);
    }
    public void startexit()
    {
        startindicator.SetActive(false);
        endindicator.SetActive(false);
    }
    public void quitenter()
    {
        endindicator.SetActive(true);
    }
    public void quitexit()
    {
        endindicator.SetActive(false);
        endindicator.SetActive(false);
        

    }
}
