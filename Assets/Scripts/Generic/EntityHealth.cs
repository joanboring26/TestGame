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
    public Slider staminabar;

    [Header("Stamina variables")]
    public float maxStamina;
    public float stamina;
    public float staminaRechargeRate;


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
        healthbar.maxValue = maxHp;
        maxStamina = stamina;
        staminabar.maxValue = maxStamina;
        totalStates = damagedSprites.Length;
        currState = totalStates;
        StartCoroutine(checkrestart());
        healthbar.value = hp;
        staminabar.value = maxStamina;
    }

    private void FixedUpdate()
    {
        stamina = Mathf.Clamp( stamina + staminaRechargeRate, 0, maxStamina);
        staminabar.value = stamina;
    }

    public void ModHealth(float givVal)
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

    public void ModStamina(float givVal)
    {
        stamina += givVal;
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
