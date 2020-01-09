using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    public GameObject MouseDirection;

    public static Transform playerTransform;

    public Rigidbody2D pRig;


    [Header("Movement vars")]
    public float speed;
    public float dashSpd;

    public bool moveEnabled;
    public float dashTime;

    public static float movHorizontal;
    public static float movVertical;

    [Header("Audio Vars")]

    public AudioSource walkSource;
    public AudioSource dashSource;

    private void Start()
    {
        playerTransform = transform;
        walkSource = GetComponent<AudioSource>();
    }
    public void PlayerMove()
    {
        if (moveEnabled)
        {
            movHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            movVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            pRig.velocity = new Vector2(movHorizontal, movVertical);

            //transform.Translate(movHorizontal, movVertical, 0);
            walkSource.UnPause();

        }
        else
        {
            movHorizontal = Input.GetAxis("Horizontal");
            movVertical = Input.GetAxis("Vertical");
        }
    }

    public void InitDash()
    {
        StartCoroutine(dashMove());
    }

    public void deadPlayer()
    {
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<PMove>());
        Destroy(GetComponent<PInputs>());
        walkSource.Stop();
        Destroy(MouseDirection);
    }

    /*
    IEnumerator rollMove()
    {
        moveEnabled = true;
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
            pRig.velocity = new Vector2(tempVec.x * -rollSpeed, tempVec.y * -rollSpeed);
            yield return new WaitForEndOfFrame();
        }
        moveEnabled = false;
        pRig.velocity = new Vector2(tempVec.x, tempVec.y);
    }
    */

    IEnumerator dashMove()
    {
        /*
        dashSource.Play();
        Vector2 tempVec;
        tempVec.x = movHorizontal * Time.deltaTime;
        tempVec.y = movVertical * Time.deltaTime;
        tempVec.Normalize();
        pRig.velocity = new Vector2(tempVec.x * dashSpd, tempVec.y * dashSpd);
        moveEnabled = false;
        yield return new WaitForSeconds(dashTime);
        moveEnabled = true;
        */
        moveEnabled = false;
        Vector2 tempVec;
        tempVec.x = 0;
        tempVec.y = 0;
        float nextRoll = Time.time + dashTime;
        while (nextRoll > Time.time)
        {
            tempVec.x = movHorizontal * Time.deltaTime;
            tempVec.y = movVertical * Time.deltaTime;
            tempVec.Normalize();
            tempVec *= dashSpd;
            pRig.velocity = new Vector2(tempVec.x * dashSpd, tempVec.y * dashSpd);
            yield return new WaitForEndOfFrame();
        }
        moveEnabled = true;

    }

}