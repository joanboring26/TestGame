using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLvl1()
    {
        SceneManager.LoadScene("level 1");
    }
     public void PlayLvl2()
    {
        SceneManager.LoadScene("Level2");
    }
      public void PlayTuto()
    {
        SceneManager.LoadScene("2d Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
