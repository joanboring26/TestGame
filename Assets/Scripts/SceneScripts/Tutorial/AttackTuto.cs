using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTuto : MonoBehaviour
{
    public bool dontCheck;
    public GameObject attack;
    public GameObject objMarker;
    public GameObject gateBlocker;
    public GameObject tip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dontCheck)
        {
            if (collision.tag == "Parry")
            {
                attack.SetActive(true);
            }
        }
    }

    public void EnemyDead()
    {
        objMarker.SetActive(true);
        tip.SetActive(true);
        Destroy(attack);
        Destroy(gateBlocker);
    }
}
