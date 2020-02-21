using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBase : MonoBehaviour
{
    public AttackBase attackBaseRef;

    public PickupInupts inputChecker;

    public InventoryManager managerRef;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (managerRef == null && collision.tag == "Player")
        {
            Debug.Log(collision);
            managerRef = collision.GetComponent<InventoryManager>();
            managerRef.showItem(attackBaseRef);
            inputChecker.enabled = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (managerRef == null && collision.tag == "Player")
        {
            Debug.Log(collision);
            managerRef = GetComponent<InventoryManager>();
            managerRef.hideItem();
            inputChecker.enabled = false;
            managerRef.m1m2Enabled = true;
        }
    }
}
