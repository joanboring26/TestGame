using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public GameObject inspectHolder;
    public Image itemImage;
    public TextMeshProUGUI name;
    public TextMeshProUGUI type;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI attackRate;
    public TextMeshProUGUI staminaUse;

    public void updateItem(Sprite gitemImage, string gname, string gtype, string gdamage, string gattackRate,string gstaminaUse)
    {
        inspectHolder.SetActive(true);
        if (name.text != gname)
        {
            itemImage.sprite = gitemImage;
            name.text = gname;
            type.text = gtype;
            damage.text = gdamage;
            attackRate.text = gdamage;
            staminaUse.text = gstaminaUse;
        }
    }

    public void hideItem()
    {
        /*
        name.text = "Unknown";
        type.text = "Unknown";
        damage.text = "Unknown";
        attackRate.text = "Unknown";
        staminaUse.text = "Unknown";
        */
        inspectHolder.SetActive(false);
    }
}
