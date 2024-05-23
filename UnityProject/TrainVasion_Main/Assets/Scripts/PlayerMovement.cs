using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Vector3 AddForce = Vector3.zero;
    public float speed = 10.0f;
    private float rotationSpeed = 150.0f;

    private void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horMove, 0f, verMove) * speed * Time.deltaTime;

        transform.Translate(movement);

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            UnityEngine.Debug.Log("WORKING");
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        }
        
    }

}
