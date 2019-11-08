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
        Vector2 tempVec;
        tempVec.x = movHorizontal * Time.deltaTime;
        tempVec.y = movVertical * Time.deltaTime;
        tempVec.Normalize();
        pRig.velocity = new Vector3(tempVec.x * dashSpd, 0, tempVec.y * dashSpd);
    }

    public void InitRoll()
    {
        StartCoroutine(rollMove());
    }

    IEnumerator rollMove()
    {
        isRolling = true;
        Vector2 tempVec;
        tempVec.x = 0;
        tempVec.y = 0;
        float nextRoll = Time.time + rollTime;
        while (nextRoll > Time.time)
        {
            tempVec.x = movHorizontal * Time.deltaTime;
            tempVec.y = movVertical * Time.deltaTime;
            tempVec.Normalize();
            tempVec *= rollSpeed;
            pRig.velocity = new Vector3(tempVec.x * -rollSpeed, 0, tempVec.y * -rollSpeed);
            yield return new WaitForEndOfFrame();
        }
        isRolling = false;
        pRig.velocity = new Vector3(tempVec.x, 0, tempVec.y);
    }
}
