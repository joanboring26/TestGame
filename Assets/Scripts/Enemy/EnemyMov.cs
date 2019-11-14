using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{
    Vector3 currentDest;
    Vector3 lastSeenEnemyPos;

    public Transform player;
    public NavMeshAgent nav;
    
    

    // Start is called before the first frame update
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MoveToDestination( Vector3 givDest)
    {
        currentDest = givDest;
        nav.SetDestination(givDest);
    }

    public void EnemyDead()
    {
        Destroy(gameObject);
    }
}
