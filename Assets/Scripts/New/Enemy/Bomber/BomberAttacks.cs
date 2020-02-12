using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAttacks : MonoBehaviour
{

    [Header("Other variables")]
    public GameObject explosion;
    public GameObject objectBase;
    public bool canDetonate = true;
    public EnemyVision visScript;
    public IEnumerator explIEnum;

    public Material mat;
    public Color initCol;

    private float colChangeAm = 4;

    [Header("Time variables")]
    public float preReadyTime;
    public float detonationTime;

    [Header("Audio variables")]
    public AudioSource soundSource;
    public AudioClip preReadySound;
    public AudioClip detonationSound;

    private void Start()
    {
        explIEnum = startExpl();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canDetonate && (collision.tag == "Player"))
        {
            StartCoroutine(explIEnum);
        }
    }

    public IEnumerator startExpl()
    {
        StartCoroutine(starColChange());
        canDetonate = false;
        visScript.movScript.nav.isStopped = true;
        visScript.movScript.nav.enabled = false;
        visScript.enabled = false;
        soundSource.PlayOneShot(preReadySound);
        yield return new WaitForSeconds(preReadyTime);

        soundSource.PlayOneShot(detonationSound);
        yield return new WaitForSeconds(detonationTime);
        if (!canDetonate)
        {
            Debug.Log("AAAA!!");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(objectBase);
        }
    }


    public IEnumerator starColChange()
    {
        mat.color = initCol;
        while (mat.color.g > 0)
        {
            mat.color = new Color( mat.color.r, Mathf.Clamp(mat.color.g - colChangeAm, 0, 255), mat.color.b);
            yield return new WaitForEndOfFrame();
        }

    }

}
