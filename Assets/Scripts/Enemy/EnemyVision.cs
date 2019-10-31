using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public EnemyMov movScript;


    public float checkDelay;
    float nextCheck = 0;

    Transform detectedTransform;

    private void OnTriggerStay(Collider other)
    {
        detectedTransform = other.transform;
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkDelay;
            if(CheckRay())
            {
                movScript.MoveToDestination(detectedTransform.position);
            }
        }
    }

    bool CheckRay()
    {
        RaycastHit hitInfo;
        Physics.Raycast(transform.position, detectedTransform.position - transform.position, out hitInfo, Mathf.Infinity, ~(14 << 14));
        Debug.DrawRay(transform.position, detectedTransform.position - transform.position, Color.red, ~(14 << 14));
        if (hitInfo.collider.tag == "Player")
        {
            return true;
        }
        return false;
    }
}