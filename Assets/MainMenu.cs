using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLvl1()
    {
        SceneManager.LoadScene("level_1");
    }
    public void PlayLvl2()
    {
        SceneManager.LoadScene("level_2");
    }
    public void PlayLvl3()
    {
        SceneManager.LoadScene("level_3");
    }

    public void PlayLvl4()
    {
        SceneManager.LoadScene("level_4_1");
    }
    public void PlayLvl5()
    {
        SceneManager.LoadScene("level_5");
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
