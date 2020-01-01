using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotTest : MonoBehaviour
{
    public Transform holder;
    public Rigidbody2D rig;
    public Material mat;
    float yRot = 0;
    // Update is called once per frame
    float angle;

    //The variable CurrTransparency can only go from 0 to 1

    void Update()
    {
        yRot = (yRot + rig.velocity.sqrMagnitude * 500 * Time.deltaTime) % 360;
        mat.color = new Color( 1, 1, 1, rig.velocity.sqrMagnitude / 10);
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;
            holder.localRotation = Quaternion.Euler(0, 0, angle);
        }
        transform.localRotation = Quaternion.Euler(0, yRot, 0);
    }
}
