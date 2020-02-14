using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberHealth : EnemyHealth
{
    [Header("Bomber variables")]

    bool launching = false;
    public float pushForce;

    public BomberAttacks bomberAtks;
    public GameObject detectExplColl;
    public GameObject detectPlayerColl;
    public GameObject trail;



    // Update is called once per frame
    public override void ModHealth(float givVal, Transform attackDir)
    {

        if (Time.time > nextDamage)
        {
            hp += givVal;
            nextDamage = Time.time + nextDamageDelay;

            if (!bomberAtks.canDetonate && !launching)
            {
                Debug.Log("LAUNCHING!!");
                Vector3 launchDir = attackDir.up;
                rig.drag = 0;
                rig.angularDrag = 0;
                rig.velocity = launchDir * pushForce;
                detectExplColl.SetActive(true);
                bomberAtks.canDetonate = false;
                bomberAtks.StopAllCoroutines();
                StopCoroutine(bomberAtks.explIEnum);
                this.enabled = false;
                trail.SetActive(true);
            }

        }
    }
}
