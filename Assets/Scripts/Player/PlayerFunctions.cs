using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    Rigidbody pRig;

    [Header("Movement vars")]
    public float speed;
    public float dashSpd;

    public static float movHorizontal;
    public static float movVertical;

    public void playerMove()
    {
        movHorizontal = Input.GetAxis("Horizontal") * -speed;
        movVertical = Input.GetAxis("Vertical") * -speed;
        movHorizontal *= Time.deltaTime;
        movVertical *= Time.deltaTime;
        transform.Translate(movHorizontal, pRig.velocity.y * Time.deltaTime, movVertical);
    }

    public void initDash()
    {
        pRig.AddForce(new Vector3(movHorizontal * dashSpd, 0, movVertical * dashSpd));
    }

    public void initRoll()
    {

    }

    public void startDefend()
    {

    }
}
