using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PInputs : MonoBehaviour
{
    public EntityHealth pStats;
    public PMove pFunc;
    public PAttSyst pAttack;
    public PVisuals pVisuals;
    public PParry pPSystem;

    [Header("Stamina requirements")]
    public float minStamAttk;
    public float minStamDash;
    public float minStamPrry;
    public float parryStaminaUse;
    public float dashStaminaUse;
    public float attackStaminaUse;

    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI text;

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            pFunc.PlayerMove();
        }

        
        else
        {
            pFunc.walkSource.Pause();
        }

        if (Input.GetButtonDown("Dash"))
        {
            if(pStats.stamina > minStamDash)
            {
                pStats.ModStamina(-dashStaminaUse);
                pFunc.InitDash();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(pAttack.initAttack() && (pStats.stamina > minStamAttk))
            {
                pStats.ModStamina(-attackStaminaUse);
                pVisuals.attackUpdate(pAttack.attackBox, pAttack);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (pAttack.canAttack() && !pPSystem.parrying)
            {
                if (pPSystem.DoParry() && (pStats.stamina > minStamAttk))
                {
                    pStats.ModStamina(-parryStaminaUse);
                }
            }
        }
    }

    IEnumerator WriteText()
    {
        while (true)
        {
            Debug.Log(text.text);
            yield return new WaitForSeconds(1f);
        }
    }
}
