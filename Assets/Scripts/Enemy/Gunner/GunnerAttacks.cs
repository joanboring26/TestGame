using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAttacks : MonoBehaviour
{
    public GameObject projectile;

    public Transform muzzleFire;

    public float fireRate;
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
                Instantiate(projectile, muzzleFire.position, muzzleFire.rotation);
            }
        }
    }



}
