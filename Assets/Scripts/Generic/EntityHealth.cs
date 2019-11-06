using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public float hp;
    public GameObject deadSprite;

    public bool alreadyHit;

    public float nextDamageDelay;

    //Script will broadcast this message to the thing it is attached to when it dies
    public string deathMessage;

    // Start is called before the first frame update

    float nextDamage = 0;


    void ModHealth(float givVal)
    {
        if(Time.time > nextDamage)
        {
            nextDamage = Time.time + nextDamageDelay;
            hp += givVal;

            if (hp <= 0)
            {
                Instantiate(deadSprite, transform.position, transform.rotation);
                SendMessageUpwards(deathMessage, hp);
            }
        }
    }

}
