using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{

    public PlayerFunctions pFunc;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            pFunc.PlayerMove();
        }

        if(Input.GetButtonDown("Dash"))
        {
            pFunc.InitDash();
        }

        if(Input.GetMouseButtonDown(0))
        {
            pFunc.StartDefend();
        }

        if(Input.GetButtonDown("Roll"))
        {
            pFunc.InitRoll();
        }
    }
}
