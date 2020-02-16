using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInupts : MonoBehaviour
{
    public PickupBase baseRef;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if(Input.GetMouseButtonDown(0))
            {
                baseRef.managerRef.setWeapon(1, baseRef.attackBaseRef);
                
            }
            else if (Input.GetMouseButtonDown(1))
            {
                baseRef.managerRef.setWeapon(2, baseRef.attackBaseRef);
            }
        }
    }
}
