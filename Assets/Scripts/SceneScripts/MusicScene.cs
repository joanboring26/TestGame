using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScene : MonoBehaviour
{
    public AudioSource musicSrc;

    public static string currScene;
    public static string prevScene;
    public static float timeStamp;
    public void setTimeStamp()
    {
        timeStamp = musicSrc.time;
    }

    public void loadMusic()
    {
        if (currScene == prevScene)
        {
            musicSrc.time = timeStamp;
        }
        else
        {
            musicSrc.time = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
