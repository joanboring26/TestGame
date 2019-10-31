using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackBase;
    public float activeAttackTime;
    public float attackDmg;

    private void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage("ModHealth", attackDmg);
        attackBase.BroadcastMessage("targetHit");
    }

    public IEnumerator attack()
    {
        GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(activeAttackTime);
        GetComponent<BoxCollider>().enabled = false;
    }
}
