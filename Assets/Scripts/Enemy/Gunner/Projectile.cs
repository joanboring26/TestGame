using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rig;
    public LayerMask parryTargets;

    public float lifeTime;
    public float damage;
    public float velocity;
    public float parryVelocity;
    public float parryTargetSearchRadius;

    public bool parried;
    private bool destroy = true;


    private void Start()
    {
        rig.AddRelativeForce(new Vector3(velocity, 0, 0), ForceMode.VelocityChange);
        StartCoroutine(destroyOverTime());
    }

    bool findParryTarget()
    {
        destroy = false;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, parryTargetSearchRadius, parryTargets);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].tag == "NPC")
            {
                Debug.DrawLine(transform.position, hitColliders[i].transform.position, Color.red, 20);
                transform.rotation = Quaternion.LookRotation(hitColliders[i].transform.position - transform.position) * Quaternion.Euler(0,-90,0);
                rig.AddRelativeForce(new Vector3(parryVelocity, 0, 0), ForceMode.VelocityChange);
                //transform.rotation = Quaternion.LookRotation(new Vector3(transform.position.x - hitColliders[i].transform.position.x, 0, transform.position.z - hitColliders[i].transform.position.z), transform.up);
                //rig.velocity = new Vector3(transform.position.x - hitColliders[i].transform.position.x, 0, transform.position.z - hitColliders[i].transform.position.z).normalized * parryVelocity;

                return true;
            }
            i++;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "NPC")
        {
            other.SendMessage("ModHealth", damage);
        }
        if(other.tag == "Parry")
        {
            gameObject.layer = 12;
            findParryTarget();
        }
        if (destroy || other.tag == "NPC")
        {
            Destroy(gameObject);
        }
    }


    IEnumerator destroyOverTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

}
