﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMover : MonoBehaviour
{
    //Recoil y cLerp determinan la posicion actual de la cámara entre el Mouse y el jugador, 0.5 = 50% de posicion, osea que está en medio de la posicion
    /*
    private float CAM_POS = 0.5f;
    float recoil = 0.5f;
    */
    public Transform cameraShakeHolder;
    public Transform player;


    float cLerp = 0.5f;

    float shakeAmt;
    Vector3 hitDir = new Vector3();
    Vector3 firstDir = new Vector3();

    public float recoveryRate;
    public float maxRecoil;
    public float recoilDuration;

    //public float xRecoilTest;
    //public float yRecoilTest;
    //public float zRecoilTest;

    public float mouseRange;

    private bool camMove = true;

    private void FixedUpdate()
    {
        //Debug.Log(Quaternion.LookRotation((player.position - MousePointer.MousePos), player.up).eulerAngles);
        if (camMove)
        {
            cLerp = Mathf.Lerp(cLerp, 0.5f, recoveryRate);
            transform.position = Vector3.Lerp(MousePointer.MousePos, player.position, cLerp);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, player.position.x - mouseRange, player.position.x + mouseRange), transform.position.y + 10, Mathf.Clamp(transform.position.z, player.position.z - mouseRange, player.position.z + mouseRange));
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + hitDir.x + firstDir.x, transform.position.y + hitDir.y + firstDir.y, transform.position.z + hitDir.z + firstDir.z), Time.deltaTime * 10f);
        }
    }

    public void CamStatus(bool var)
    {
        camMove = var;
    }

    public void camShake(float recoil)
    {
        shakeAmt = recoil;
        //StartCoroutine(cameraHit(givHitDir));
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", recoilDuration);
    }

    public void DoShake()
    {
        if(shakeAmt > 0)
        {
            Vector3 camPos = cameraShakeHolder.position;

            float offsetX = Random.Range(-shakeAmt, shakeAmt) * - 1.2f;
            float offsetY = Random.Range(-shakeAmt, shakeAmt) * - 1.2f;

            camPos.x += offsetX;
            camPos.z += offsetY;

            cameraShakeHolder.transform.position = camPos;
        }
    }

    public void StopShake()
    {
        CancelInvoke("DoShake");
        cameraShakeHolder.localPosition = Vector3.zero;
    }

    /*
    IEnumerator cameraHit(Vector3 givHitDir)
    {
        hitDir = givHitDir;
        bool beingHit = true;
        bool hitP1 = true;
        while(beingHit)
        {
            
            if(hitP1)
            {
                
                firstDir.x = Mathf.Lerp(firstDir.x, hitDir.x, Time.deltaTime * 15f);
                firstDir.y = Mathf.Lerp(firstDir.y, hitDir.y, Time.deltaTime * 15f);
                firstDir.z = Mathf.Lerp(firstDir.z, hitDir.z, Time.deltaTime * 15f);
                if ((firstDir.x < (hitDir.x + 0.2f) && hitDir.x > (hitDir.x - 0.2f)) && (firstDir.y < (hitDir.y + 0.2f) && hitDir.y > (hitDir.y - 0.2f)) && (firstDir.z < (hitDir.z + 0.2f) && hitDir.z > (hitDir.z - 0.2f)))
                {
                    hitP1 = false;
                }                
            }
            else
            {
                hitDir.x = Mathf.Lerp(hitDir.x, 0, Time.deltaTime * xRecoilTest);
                hitDir.y = Mathf.Lerp(hitDir.y, 0, Time.deltaTime * yRecoilTest);
                hitDir.z = Mathf.Lerp(hitDir.z, 0, Time.deltaTime * zRecoilTest);
                if ((hitDir.x < 0.2f && hitDir.x > -0.2f) && (hitDir.y < 0.2f && hitDir.y > -0.2f) && (hitDir.z < 0.2f && hitDir.z > -0.2f))
                {
                    beingHit = false;
                }
            }
            yield return new WaitForEndOfFrame();
        }
        firstDir = Vector3.zero;
        hitDir = Vector3.zero;
    }
    */

}

