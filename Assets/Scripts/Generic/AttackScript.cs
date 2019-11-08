using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackBase;
    public float activeAttackColliderTime;
    public float attackDmg;

    private void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("ModHealth", attackDmg);
        if(attackBase!= null)
        {
            attackBase.BroadcastMessage("targetHit");
        }
    }

    public IEnumerator attack()
    {
        GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(activeAttackColliderTime);
        GetComponent<BoxCollider>().enabled = false;
    }
}
