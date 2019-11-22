using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : MonoBehaviour
{
    public float hp;
    public GameObject deadSprite;
    public Slider healthbar; 
    

    public float nextDamageDelay;

    //Script will broadcast this message to the thing it is attached to when it dies
    public string deathMessage;
    public GameObject hitMessageTarget;
    public string hitMessage;
    public GameObject explosionRef;

    public AudioSource painSrc;
    public AudioClip[] hitSnds;
    // Start is called before the first frame update

    float nextDamage = 0;

    private void Start()
    {
        StartCoroutine(checkrestart());
        healthbar.value = hp; 
    }
    void ModHealth(float givVal)
    {
        if(Time.time > nextDamage)
        {
            nextDamage = Time.time + nextDamageDelay;
            hp += givVal;

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
