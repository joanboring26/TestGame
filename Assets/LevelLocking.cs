using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelLocking : MonoBehaviour
{

    int Levels; 

   public GameObject[] Level;

    private void Start()
    {
        Levels = PlayerPrefs.GetInt("Levels", 1);

        //Levels = (int)Mathf.Pow(2f,0f);
        for (int i = 0; i < Level.Length; i++)
        {
            Level[i].SetActive((Levels >> i) % 2 == 1);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerPrefs.DeleteKey("Levels");


            Levels = PlayerPrefs.GetInt("Levels", 1);
            for (int i = 0; i < Level.Length; i++)
            {
                Level[i].SetActive((Levels >> i) % 2 == 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
          
            for (int i = 0; i < Level.Length; i++)
            {
                Levels += (int)Mathf.Pow(2f, i);
                Level[i].SetActive((Levels >> i) % 2 == 1);
            }

            PlayerPrefs.SetInt("Levels", Levels);

        }

    }


}
