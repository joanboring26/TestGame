using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{

    public GameObject attackSprite;

    public void attackUpdate(AttackScript givAtkScript)
    {
        attackSprite.SetActive(true);
        StartCoroutine(attackUpdateVisuals(givAtkScript));
    }

    IEnumerator attackUpdateVisuals(AttackScript givAtkScript)
    {
        yield return new WaitForSeconds(givAtkScript.activeAttackColliderTime);
        attackSprite.SetActive(false);
    }


}
