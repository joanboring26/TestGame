using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float attackDmg;
    private void OnTriggerEnter(Collider other)
    {
        other.SendMessage("ModHealth", attackDmg);
    }
}
