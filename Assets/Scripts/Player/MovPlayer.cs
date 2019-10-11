using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    [Header("Movement vars")]
    public float speed;

    public static float movHorizontal;
    public static float movVertical;

    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void playerMove()
    {
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            movHorizontal = Input.GetAxis("Horizontal") * -speed;
            movVertical = Input.GetAxis("Vertical") * -speed;
            movHorizontal *= Time.deltaTime;
            movVertical *= Time.deltaTime;
            transform.Translate(movHorizontal, rig.velocity.y * Time.deltaTime, movVertical);
        }
    }
}
