using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAttacks : MonoBehaviour
{
    public GameObject projectile;
    public GameObject attackAnims;

    public Transform muzzleFire;
    public AudioSource fireSnd;

    public float fireRate;
    public int bulletsPerBurst;
    public float attackCooldown;
    public bool dontAttack;

    private float nextAttack = 0;

    private void OnTriggerStay2D(Collider2D other)
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
        attackAnims.SetActive(true);
        for(int i = 0; i < bulletsPerBurst ; i++)
        {
            fireSnd.PlayOneShot(fireSnd.clip);
            Instantiate(projectile, muzzleFire.position, muzzleFire.rotation);
            yield return new WaitForSeconds(fireRate);
        }
        attackAnims.SetActive(false);
    }

}
