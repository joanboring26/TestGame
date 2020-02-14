using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDoor : MonoBehaviour
{
    public GameObject door;
    public void EnemyDead()
    {
        door.GetComponent<DoorCounter>().substractVal(1);
    }
}
