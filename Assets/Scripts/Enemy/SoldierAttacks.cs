using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttacks : MonoBehaviour
{
    public GameObject preAttackSprite;
    public GameObject attackingSprite;

    public float attackDelay;



    void attackStarted()
    {
        attackingSprite.SetActive(true);
    }
    void attackDone()
    {
        attackingSprite.SetActive(false);
    }

    IEnumerator preAttack()
    {
        preAttackSprite.SetActive(true);
        attackingSprite.SetActive(false);
        yield return new WaitForSeconds(attackDelay);
        preAttackSprite.SetActive(false);
        attackingSprite.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }
    }

}
