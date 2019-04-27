using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_manager : MonoBehaviour
{

    public float playerSpeed = 1f;

    private void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetAxis("Vertical") > 0)
        {
            movement += new Vector3(0, playerSpeed, 0);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            movement -= new Vector3(0, playerSpeed, 0);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            movement += new Vector3(playerSpeed, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            movement -= new Vector3(playerSpeed, 0, 0);
        }
        GetComponent<Rigidbody2D>().velocity = movement;

    }

}
