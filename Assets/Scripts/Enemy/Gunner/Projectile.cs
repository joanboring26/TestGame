using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rig;

    public float damage;
    public float velocity;

    private void Start()
    {
        rig.AddRelativeForce(new Vector3(velocity, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<EntityHealth>().BroadcastMessage("ModHealth", damage);
        }
        Destroy(gameObject);
    }

}
