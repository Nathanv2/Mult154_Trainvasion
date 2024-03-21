using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Vector3 AddForce = Vector3.zero;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        AddForce = horMove * Vector3.left + verMove * Vector3.back;
    }

    // Update is called for once per frame
    void FixedUpdate()
    {
        Vector3 movement = AddForce * speed * Time.deltaTime;
        rbPlayer.AddForce(movement, ForceMode.Impulse);
    }
}
