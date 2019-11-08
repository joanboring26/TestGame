using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    public EnemyMov movScript;

    public float rotationSpeed;
    public bool lookAtTarget;
    bool detectedTarget;
    
    public float checkDelay;
    float nextCheck = 0;

    public Transform detectedTransform;
    public Transform npcTransform;

    private void Update()
    {
        if(detectedTarget && lookAtTarget)
        {
            var newRotation = Quaternion.LookRotation( detectedTransform.position - npcTransform.position).eulerAngles;
            newRotation.x = 0;
            newRotation.z = 0;
            npcTransform.rotation = Quaternion.Slerp(npcTransform.rotation, Quaternion.Euler(newRotation), Time.deltaTime * rotationSpeed);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        detectedTransform = other.transform;
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkDelay;
            if(CheckRay())
            {
                movScript.MoveToDestination(detectedTransform.position);
                detectedTarget = true;
            }
            else
            {
                detectedTarget = false;
            }
        }
    }

    bool CheckRay()
    {
        RaycastHit hitInfo;
        Physics.Raycast(transform.position, detectedTransform.position - transform.position, out hitInfo, Mathf.Infinity, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, detectedTransform.position - transform.position, Color.red, LayerMask.GetMask("Player"));
        if (hitInfo.collider.tag == "Player")
        {
            return true;
        }
        return false;
    }



}