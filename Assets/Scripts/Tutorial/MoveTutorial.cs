using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTutorial : MonoBehaviour
{
    public Timescale time;

    public GameObject panel;
  
    void Start()
    {

        time.Stop();
        panel.SetActive(true);

    }


    void Update()
    {
      
        if (Input.GetButtonDown("Roll"))
        {
            time.Resume();
            panel.SetActive(false);
            
        }


    }
}
