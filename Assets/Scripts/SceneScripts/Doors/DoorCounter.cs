using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCounter : MonoBehaviour
{
    public int numOfEnemies;
    public GameObject door;

    // Start is called before the first frame update
    public void substractVal(int val)
    {
        numOfEnemies -= val;
        if(numOfEnemies <= 0)
        {
            Destroy(door);
            Destroy(gameObject);
        }
    }
}
