using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{
    public Transform player;
    
    public float speed = 4;
    private NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
   

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        nav.destination = player.transform.position;
        /*
        if (Vector3.Distance(transform.position, player.position) > 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        */
        
    }
}
