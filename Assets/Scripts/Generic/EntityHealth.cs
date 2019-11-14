﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public float hp;
    public GameObject deadSprite;
    

    public float nextDamageDelay;

    //Script will broadcast this message to the thing it is attached to when it dies
    public string deathMessage;
    public GameObject hitMessageTarget;
    public string hitMessage;
    private UnityEngine.Object explosionRef;
    // Start is called before the first frame update

    float nextDamage = 0;

    void Start()
    {
        explosionRef = Resources.Load("Explosion");
        
    }

    void ModHealth(float givVal)
    {
        if(Time.time > nextDamage)
        {
            nextDamage = Time.time + nextDamageDelay;
            hp += givVal;
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            if (hitMessageTarget != null)
            {
                hitMessageTarget.SendMessage(hitMessage, 0.3f);
            }

            if (hp <= 0)
            {
                Instantiate(deadSprite, transform.position, transform.rotation);
                gameObject.SendMessage(deathMessage, hp);
            }
        }
    }

}
