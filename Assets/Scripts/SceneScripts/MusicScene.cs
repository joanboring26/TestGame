using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScene : MonoBehaviour
{
    public AudioSource musicSrc;

    public static string prevScene = "none";
    public static float timeStamp = 0;

    private void Start()
    {
        if(prevScene != SceneManager.GetActiveScene().name)
        {
            prevScene = SceneManager.GetActiveScene().name;
            timeStamp = 0;
        }
        loadMusic();
    }
    public void setTimeStamp()
    {
        timeStamp = musicSrc.time;
    }

    public void loadMusic()
    {
        musicSrc.time = timeStamp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
