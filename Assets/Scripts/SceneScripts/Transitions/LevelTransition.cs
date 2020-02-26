using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    GameObject door;
    public string nextLevel;
    public float fadeTime;
    public GameObject doorToClose;
    public Image render;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(fadeTimer(fadeTime));
    }

    public IEnumerator fadeTimer(float fadeTime)
    {
        render.color = new Color(render.color.r, render.color.g, render.color.b, 0);
        float fadeDurationInSeconds = fadeTime;
        float timeout = 0.05f;
        float fadeAmount = 1 / (fadeDurationInSeconds / timeout);

        for (float f = 0; f <= 1; f += fadeAmount)
        {
            Color c = render.color;
            c.a = f;
            render.color = c;
            yield return new WaitForSeconds(timeout);
        }

        render.color = new Color(render.color.r, render.color.g, render.color.b, 255);
        SceneManager.LoadScene(nextLevel);
    }

}
