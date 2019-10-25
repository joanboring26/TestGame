using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public float damage;

    public float attackRate;

    public GameObject attackBox;

    private bool canAttack;

    public void Start()
    {
        attackBox.GetComponent<AttackScript>().attackDmg = damage;
    }

    public void initAttack()
    {
        if(canAttack)
        {
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        canAttack = false;
        attackBox.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
        attackBox.GetComponent<BoxCollider>().enabled = false;
    }

}
