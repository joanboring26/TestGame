using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject UICanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
                Debug.Log("Resumed");
            }
            else
            {
                Pause();
                Debug.Log("Paused");
            }
        }
    }

    public void Resume() {

        pauseMenu.SetActive(false);
        UICanvas.SetActive(true);
        gamePaused = false;
        Time.timeScale = 1f;
        
    }

    void Pause() {

        pauseMenu.SetActive(true);
        UICanvas.SetActive(false);
        gamePaused = true;
        Time.timeScale = 0f;
       
        

    }

    public void toMainMenu() {

        SceneManager.LoadScene("NewMainMenu");
      
    }

    public void Quit()
    {
        Application.Quit();
    }
}
