using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hp;
    float maxHp;
    public GameObject deadSprite;


    public float nextDamageDelay;

    //Script will broadcast this message to the thing it is attached to when it dies
    public string deathMessage;
    public GameObject hitMessageTarget;
    public string hitMessage;
    public GameObject explosionRef;
    public Rigidbody2D rig;

    [Header("Damaged visuals")]
    public MeshRenderer meshRenderer;
    public Material[] damagedSprites;
    public GameObject damageChunks;
    public GameObject deathChunks;
    int totalStates;
    int currState;

    float nextDamage = 0;

    private void Start()
    {
        maxHp = hp;
        totalStates = damagedSprites.Length;
        currState = totalStates;
        totalStates--;
    }

    void ModHealth(float givVal)
    {
        if (Time.time > nextDamage)
        {
            nextDamage = Time.time + nextDamageDelay;
            hp += givVal;
            currState = Mathf.RoundToInt((hp / maxHp) * totalStates);

            Instantiate(explosionRef, transform.position, transform.rotation);
            if (hitMessageTarget != null)
            {
                hitMessageTarget.SendMessage(hitMessage, 0.3f);
            }

            if (hp <= 0)
            {
                Instantiate(deadSprite, transform.position, transform.rotation);
                Instantiate(deathChunks, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                gameObject.SendMessage(deathMessage, hp);
            }
            else
            {
                meshRenderer.material = damagedSprites[currState];
                Instantiate(damageChunks, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            }

        }
    }
}
