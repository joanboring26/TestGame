using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierAttacks : MonoBehaviour
{
    public EnemyVision givVision;
    public EnemyAttackScript givAttackScript;

    public GameObject preAttackSprite;
    public GameObject attackingSprite;

    public Transform enemyTransform;

    public Rigidbody rig;

    public NavMeshAgent aiAgent;

    public AudioClip preAttackSnd;
    public AudioClip attackSnd;
    public AudioClip stunnedSnd;
    public AudioSource sndSrc;

    public float activeAttackTime;
    public float preAttackSpd;
    public float attackSpd;
    public float stunForce;

    public float attackCooldown;
    public float stunCooldown;

    public float attackDelay;



    float nextAttack;
    Vector3 attackPos;

    private bool dontAttack = false;

    void preAttackStarted()
    {
        sndSrc.PlayOneShot(preAttackSnd);
        attackPos = givVision.detectedTransform.position;
        givVision.npcTransform.rotation = Quaternion.LookRotation(new Vector3(givVision.detectedTransform.position.x - givVision.npcTransform.position.x, 0, givVision.detectedTransform.position.z - givVision.npcTransform.position.z));
        givVision.lookAtTarget = false;
        aiAgent.isStopped = true;
        preAttackSprite.SetActive(true);
        if (givVision.detectedTransform != null)
        {
            Vector3 atkVector = new Vector3(transform.position.x - attackPos.x, 0, transform.position.z - attackPos.z).normalized;
            rig.velocity = new Vector3(atkVector.x * preAttackSpd,0, atkVector.z * preAttackSpd);
        }
    }

    void attackStarted()
    {
        sndSrc.PlayOneShot(attackSnd);
        StartCoroutine(givAttackScript.attack());
        attackingSprite.SetActive(true);
        preAttackSprite.SetActive(false);
        if (givVision.detectedTransform != null)
        {
            Vector3 atkVector = new Vector3(transform.position.x - attackPos.x, 0, transform.position.z - attackPos.z).normalized;
            rig.velocity = new Vector3(atkVector.x * attackSpd, 0, atkVector.z * attackSpd);
        }
    }

    void attackDone()
    {
        givVision.lookAtTarget = true;
        attackingSprite.SetActive(false);
        aiAgent.isStopped = false;
    }

    IEnumerator preAttack()
    {
        preAttackStarted();
        yield return new WaitForSeconds(attackDelay);
        attackStarted();
        yield return new WaitForSeconds(activeAttackTime);
        attackDone();
        rig.velocity = rig.velocity/3;
    }

    public IEnumerator stunned(Vector3 parryPos)
    {
        sndSrc.PlayOneShot(stunnedSnd);
        givVision.enabled = false;
        givAttackScript.attackBox.enabled = false;
        givAttackScript.enabled = false;
        dontAttack = true;
        rig.velocity = new Vector3(enemyTransform.position.x - MovPlayer.playerTransform.position.x, 0, enemyTransform.position.z - MovPlayer.playerTransform.position.z).normalized * stunForce;
        yield return new WaitForSeconds(stunCooldown);
        dontAttack = false;
        givAttackScript.enabled = true;
        givAttackScript.attackBox.enabled = false;
        givVision.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Time.time > nextAttack)
        {
            if (!dontAttack)
            {
                nextAttack = Time.time + attackCooldown;
                StartCoroutine("preAttack");
            }
        }
    }

}
