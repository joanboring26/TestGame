using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAttacks : MonoBehaviour
{
    public GameObject projectile;

    public Transform muzzleFire;

    public float fireRate;
    public int bulletsPerBurst;
    public float attackCooldown;
    public bool dontAttack;

    private float nextAttack = 0;

    private void OnTriggerStay(Collider other)
    {

        if (Time.time > nextAttack)
        {
            if (!dontAttack)
            {
                nextAttack = Time.time + attackCooldown;
                StartCoroutine(Burst());
            }
        }
    }

    IEnumerator Burst()
    {
        for(int i = 0; i < bulletsPerBurst ; i++)
        {
            Instantiate(projectile, muzzleFire.position, muzzleFire.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }

}
