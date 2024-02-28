using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UIManager UImanager;
    private Rigidbody rbPlayer;
    private GameObject Player;
    public Stops[] stop;

    private float movementSpeed = 2.5f;
    private Vector3 targetPosition;

    private bool isMoving = false;
    public bool buttonpressed = false;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        stop = FindObjectsOfType<Stops>();
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
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90, 0);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("5 People"))
        {
            UImanager.TriggerSaveButtons();
            UpdateStopsToFalse();
            buttonpressed = false;
            Debug.Log("Save 5 People or leave them to suffer!");
        }
        else if (other.gameObject.CompareTag("10 People"))
        {
            UImanager.TriggerSaveButtons();
            UpdateStopsToFalse();
            buttonpressed = false;
            Debug.Log("Save 10 People or leave them to suffer!");
        }
        else if (other.gameObject.CompareTag("15 People"))
        {
            UImanager.TriggerSaveButtons();
            UpdateStopsToFalse();
            buttonpressed = false;
            Debug.Log("Save 15 People or leave them to suffer!");
        }
        else if (other.gameObject.CompareTag("Saved"))
        {
            Debug.Log("Already cleared!");
        }
        else if (other.gameObject.CompareTag("Blockade 1"))
        {
            UImanager.TriggerBlockadeButtons();
            UpdateStopsToFalse();
            buttonpressed = false;
            Debug.Log("Remove Blockade or Go Back!");
        } 
        else if (other.gameObject.CompareTag("Blockade 2"))
        {
            UImanager.TriggerBlockadeButtons();
            UpdateStopsToFalse();
            buttonpressed = false;
            Debug.Log("Remove Blockade or Go Back!");
        } 
        else if (other.gameObject.CompareTag("Blockade 3"))
        {
            UImanager.TriggerBlockadeButtons();
            UpdateStopsToFalse();
            buttonpressed = false;
            Debug.Log("Remove Blockade or Go Back!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (buttonpressed)
        {
            other.gameObject.tag = "Saved";
        }
    }

    public void UpdateStopsToFalse()
    {
        foreach (Stops stop in stop)
        {
            stop.canclick = false;
        }
    }

    public void UpdateStopsToTrue()
    {
        foreach (Stops stop in stop)
        {
            stop.canclick = true;
        }
    }

    public void pressedbutton()
    {
        buttonpressed = true;
    }  
}
