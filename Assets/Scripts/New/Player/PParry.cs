using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PParry : MonoBehaviour
{
    public bool parrying = false;
    public float activeParryColliderTime;

    public GameObject visualParry;

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DoParry()
    {
        StartCoroutine(Parry());
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
