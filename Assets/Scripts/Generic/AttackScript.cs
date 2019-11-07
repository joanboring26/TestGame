using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject attackBase;
    public GameObject visualManager;
    public float activeAttackTime;
    public float attackDmg;

    private void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("ModHealth", attackDmg);
        attackBase.BroadcastMessage("targetHit");
    }

    public IEnumerator attack()
    {
        visualManager.BroadcastMessage("AttackStarted");
        GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(activeAttackTime);
        GetComponent<BoxCollider>().enabled = false;
        visualManager.BroadcastMessage("AttackDone");
    }
}
