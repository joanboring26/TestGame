using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public float damage;

    public float attackRate;

    public AttackScript attackBox;

    float nextAttack = 0;

    public void Start()
    {
        attackBox.GetComponent<AttackScript>().attackDmg = damage;
    }

    public void initAttack()
    {
        if(Time.time > nextAttack)
        {
            Debug.Log("Attacking!");
            nextAttack = Time.time + attackRate;
            StartCoroutine(attackBox.attack());
        }
        else
        {
            Debug.Log("Didnt attack");
        }
    }
}
