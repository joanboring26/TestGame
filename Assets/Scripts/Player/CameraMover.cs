using System.Collections;
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

    public float recoveryRate;
    public float maxRecoil;
    public float recoilDuration;


    public float mouseRange;

    private void FixedUpdate()
    {
        cLerp = Mathf.Lerp(cLerp, 0.5f, recoveryRate);
        transform.position = Vector3.Lerp(MousePointer.MousePos, player.position, cLerp);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, player.position.x - mouseRange, player.position.x + mouseRange), transform.position.y, Mathf.Clamp(transform.position.z, player.position.z - mouseRange, player.position.z + mouseRange));

    }

    public void camShake(float recoil)
    {
        shakeAmt = recoil;
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
}

