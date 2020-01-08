using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PParry : MonoBehaviour
{
    public bool parrying = false;

    public float activeParryColliderTime;
    public float parryRate;

    public GameObject visualParry;

    float nextParry = 0;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public bool DoParry()
    {
        if (Time.time > nextParry)
        {
            nextParry = Time.time + parryRate;
            StartCoroutine(Parry());
            return true;
        }
        Debug.Log("AAAAAAAAAA");
        return false;
    }

    public IEnumerator Parry()
    {
        parrying = true;
        visualParry.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(activeParryColliderTime);
        GetComponent<BoxCollider2D>().enabled = false;
        visualParry.SetActive(false);
        parrying = false;
    }
}
