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


    [Header("Stamina variables")]
    public float maxStamina;
    public float stamina;
    public float staminaRechargeRate;
    public Slider staminabar;

    [Header("Previous health variables")]
    public float delayPrevHealth;
    public float prevHealthEmptyRate;
    public int prevHealthRecovery; //Se usa para calcular cuanta vida recupera un ataque a un enemigo
    private float prevHealth = 0;
    private bool drainPrevHealth = false;
    public Slider prevHealthBar;


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
        prevHealth = hp;
        prevHealthBar.maxValue = prevHealth;
        maxHp = hp;
        healthbar.maxValue = maxHp;
        maxStamina = stamina;
        staminabar.maxValue = maxStamina;
        totalStates = damagedSprites.Length;
        currState = totalStates;
        //StartCoroutine(checkrestart());
        prevHealthBar.value = prevHealth;
        healthbar.value = hp;
        staminabar.value = maxStamina;
    }

    private void FixedUpdate()
    {
        stamina = Mathf.Clamp( stamina + staminaRechargeRate, 0, maxStamina);
        staminabar.value = stamina;
        if (drainPrevHealth)
        {
            prevHealth = Mathf.Clamp(prevHealth - prevHealthEmptyRate, hp, maxHp);
            prevHealthBar.value = prevHealth;
        }
    }

    public void ModHealth(float givVal)
    {
        if(Time.time > nextDamage)
        {
            if (givVal < 0)
            {
                Instantiate(explosionRef, transform.position, transform.rotation);
                StartCoroutine(PrevHealthStart(givVal));
            }
            nextDamage = Time.time + nextDamageDelay;
            hp += givVal;
            currState = Mathf.RoundToInt((hp / maxHp) * 3);

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

    public void RecoverPrevHealth(int dealtDamage)
    {
        if(prevHealth > hp)
        {
            hp = Mathf.Clamp((dealtDamage / prevHealthRecovery) * dealtDamage + hp, hp, prevHealth);
            healthbar.value = hp;
        }
    }

    public void ModStamina(float givVal)
    {
        stamina += givVal;
    }

    IEnumerator PrevHealthStart( float damage)
    {
        prevHealthBar.value = hp;
        prevHealth = hp;
        drainPrevHealth = false;
        yield return new WaitForSeconds(delayPrevHealth);
        drainPrevHealth = true;
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
