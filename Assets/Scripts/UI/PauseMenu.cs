using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume() {

        pauseMenu.SetActive(false);
        UICanvas.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
        
    }

    void Pause() {

        pauseMenu.SetActive(true);
        UICanvas.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
       
        

    }

}
