using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryTutoCollision : MonoBehaviour
{
    public Timescale time;

    public GameObject panel;
    public GameObject tutorial;

    public void Start()
    {
        tutorial.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        time.Stop();
        panel.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1) && panel.activeSelf)
        {
            panel.SetActive(false);
            time.Resume();
            tutorial.SetActive(false);
            Destroy(gameObject);
        }

    }

}
