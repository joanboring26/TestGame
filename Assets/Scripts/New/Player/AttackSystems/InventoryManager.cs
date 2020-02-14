using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    AttackBase item1;
    AttackBase item2;

    public HudManager HudMan;


    public void useItem(int it)
    {
        if (it == 1)
        {
            if (item1 != null) item1.attack();
        }
        else
        {
            if (item2 != null) item2.attack();
        }
    }

    public void showItem(AttackBase givItem)
    {
        HudMan.updateItem( givItem.hudIcon, givItem.name, givItem.AtkType, givItem.AtkDamage, givItem.AtkRate, givItem.StamUse);
    }

    public void hideItem()
    {
        HudMan.hideItem();
    }
}
