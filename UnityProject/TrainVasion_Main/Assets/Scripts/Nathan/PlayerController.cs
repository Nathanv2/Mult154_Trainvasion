using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private GameObject Player;
    private float movementSpeed = 2.5f;

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            MoveTowardsTargetPosition();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, -90, 0);
            Debug.Log("A");
        }else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90, 0);
            Debug.Log("D");
        }
    }

    public void Transition(Vector3 NextStop)
    {
        targetPosition = NextStop;
        isMoving = true;
    }

    void MoveTowardsTargetPosition()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movementSpeed);
        rbPlayer.MovePosition(newPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }
}
