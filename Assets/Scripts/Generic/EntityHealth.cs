using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : MonoBehaviour
{
    [Header("Health variables")]
    public float hp;
    float maxHp;
    public Slider healthbar; 


    [Header("OnDeath variables")]
    //Script will broadcast this message to the thing it is attached to when it dies
    public string deathMessage;
    public GameObject deadSprite;

    [Header("OnHit variables")]
    public string hitMessage;
    public float nextDamageDelay;
    public GameObject hitMessageTarget;
    public GameObject explosionRef;

    [Header("Damaged visuals")]
    public Material[] damagedSprites;
    int totalStates;
    int currState;

    [Header("Audio")]
    public AudioSource painSrc;
    public AudioClip[] hitSnds;

    float nextDamage = 0;
    public float totalTime = 1;

    private void Start()
    {
        maxHp = hp;
        totalStates = damagedSprites.Length;
        currState = totalStates;
        StartCoroutine(checkrestart());
        healthbar.value = hp; 
    }
    void ModHealth(float givVal)
    {
        if(Time.time > nextDamage)
        {
            nextDamage = Time.time + nextDamageDelay;
            hp += givVal;
            currState = Mathf.RoundToInt((hp / maxHp) * 3);

            Instantiate(explosionRef, transform.position, transform.rotation);
            if (hitMessageTarget != null)
            {
                painSrc.PlayOneShot(hitSnds[Random.Range(0, hitSnds.Length)]);
                hitMessageTarget.SendMessage(hitMessage, 0.3f);
            }

            if (hp <= 0)
            {
                Instantiate(deadSprite, transform.position, transform.rotation);
                gameObject.SendMessage(deathMessage, hp);
            }
        }

        healthbar.value = hp;
    }

    IEnumerator checkrestart()
    {
        while(true)
        {
            if(Input.GetButton("Restart"))
            {
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
