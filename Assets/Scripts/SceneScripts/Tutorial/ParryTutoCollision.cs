using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryTutoCollision : MonoBehaviour
{
    public Timescale time;

    public GameObject tutorial;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        time.Stop();
        tutorial.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1) && tutorial.activeSelf)
        {
            time.Resume();
            tutorial.SetActive(false);
            Destroy(gameObject);
        }

    }

}
