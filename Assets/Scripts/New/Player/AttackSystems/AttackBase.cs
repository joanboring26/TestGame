using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    [Header("Base vars")]
    //Used to spawn the weapon or item in this relative location to the player's item holder base
    public Vector3 RelativeSpawnCoordinates;
    //Used for hud stuff
    public Sprite hudIcon;
    public string AtkType;
    public string AtkRate;
    public string AtkDamage;
    public string WepName;
    public string StamUse;

    public bool mUp;

    public EntityHealth playerStats;

    private InventoryManager managerRef;

    public virtual void attack()
    {

    }

    public virtual void mouseHeld()
    {

    }

    public virtual void mouseReleased()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (managerRef == null && collision.tag == "Player")
        {
            managerRef = GetComponent<InventoryManager>();
            managerRef.showItem(this);
        }
        else
        {
            managerRef.showItem(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (managerRef == null && collision.tag == "Player")
        {
            managerRef = GetComponent<InventoryManager>();
            managerRef.hideItem();
        }
        else
        {
            managerRef.hideItem();
        }

    }

}
