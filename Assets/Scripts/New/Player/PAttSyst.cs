using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttSyst : MonoBehaviour
{
    public float damage;

    public float attackRate;

    public PAttack attackBox;

    public bool camShakeEnabled;
    public float attackShake;
    public float giveHitShake;
    public float takeHitShake;
    public PCamMover cam;

    public float nextAttack = 0;

    public void Start()
    {
        attackBox.GetComponent<PAttack>().attackDmg = damage;
    }

    public void targetHit()
    {
        cam.camShake(giveHitShake);
    }

    public void targetParry()
    {

    }

    public bool canAttack()
    {
        if (Time.time > nextAttack)
        {
            return true;
        }
        return false;
    }

    public bool initAttack()
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            if (camShakeEnabled)
            {
                cam.camShake(attackShake);
            }
            StartCoroutine(attackBox.attack());
            return true;
        }
        else
        {
            return false;
        }
    }
}
