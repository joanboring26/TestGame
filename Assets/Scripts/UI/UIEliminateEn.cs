using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIEliminateEn : MonoBehaviour
{
    public bool destroyOnObjectiveDone;
    public string messageBefore;
    public string finalMessage;
    public int maxTargets;
    private int currTargets;
    public GameObject pointerObj;
    public TextMeshProUGUI text;

    public AudioClip objectiveDoneSnd;
    public AudioClip enemyDownSnd;
    public AudioSource sndSrc;


    private void Start()
    {
        currTargets = maxTargets;
        text.text = messageBefore + currTargets.ToString();
    }

    public void eventTrig(int valMod)
    {

        currTargets -= valMod;
        if(currTargets <= 0)
        {
            text.text = finalMessage;
            pointerObj.SetActive(true);
            sndSrc.PlayOneShot(objectiveDoneSnd);
        }
        else
        {
            text.text = messageBefore + currTargets.ToString();
            sndSrc.PlayOneShot(enemyDownSnd);
        }
    }
}
