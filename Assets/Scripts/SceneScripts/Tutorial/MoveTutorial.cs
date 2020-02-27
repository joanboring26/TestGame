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
        StartCoroutine(resTime());
    }


    void Update()
    {
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            time.Resume();
            panel.SetActive(false);
        }
    }

    IEnumerator resTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        time.Resume();
    }
}
