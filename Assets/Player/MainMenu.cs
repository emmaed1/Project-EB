using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isPaused;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game.");
        Application.Quit();
    }

    public void Pausegame()
    {
        if(Time.timeScale == 1.0f) 
        {
            Time.timeScale = 0;
        }
        
    }
    public void ResumeGame()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1;
        }
        
    }
}
