using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public Rigidbody pRig;

    [Header("Movement vars")]
    public float speed;
    public float dashSpd;

    public bool isRolling;
    public int rollLayer;
    public float rollSpeed;
    public float rollTime;

    public static float movHorizontal;
    public static float movVertical;

    public void PlayerMove()
    {
        if (!isRolling)
        {
            movHorizontal = Input.GetAxis("Horizontal") * -speed;
            movVertical = Input.GetAxis("Vertical") * -speed;
            movHorizontal *= Time.deltaTime;
            movVertical *= Time.deltaTime;
            transform.Translate(movHorizontal, pRig.velocity.y * Time.deltaTime, movVertical);
        }
        else
        {
            movHorizontal = Input.GetAxis("Horizontal");
            movVertical = Input.GetAxis("Vertical");
        }
    }

    public void InitDash()
    {
        pRig.AddForce(new Vector3(movHorizontal * dashSpd, 0, movVertical * dashSpd), ForceMode.VelocityChange);
    }

    public void InitRoll()
    {
        StartCoroutine(rollMove());
    }

    IEnumerator rollMove()
    {
        isRolling = true;
        float nextRoll = Time.time + rollTime;
        while (nextRoll > Time.time)
        {
            movHorizontal = movHorizontal * Time.deltaTime * -rollSpeed;
            movVertical = movVertical * Time.deltaTime * -rollSpeed;
            transform.Translate(movHorizontal, pRig.velocity.y * Time.deltaTime, movVertical);
            yield return new WaitForEndOfFrame();
        }
        isRolling = false;
    }
}
