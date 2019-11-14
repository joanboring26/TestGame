using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTp : MonoBehaviour
{
    Vector3 playerVector;
    Vector3 enemyVector;
    Vector3 finalVector;
    public Transform player;
    public Transform enemy;
    public GameObject tpBox;
    private void OnTriggerEnter(Collider collider)
    {
        playerVector = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        enemyVector = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
        finalVector = playerVector - enemyVector;
        finalVector = finalVector.normalized;
        if (collider.gameObject.GetComponent<BoxCollider>() == tpBox)
        {
            enemy.position = finalVector * -1;
        }

    }
    
    
}
