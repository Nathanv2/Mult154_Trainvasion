using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public UIManager UImanager;
    private Rigidbody rbPlayer;
    private GameObject Player;
    public Stops[] stop;
    public Collider test;
    private GameObject stopObject;
    public GameObject Blockade;

    private float movementSpeed = 2.5f;
    private Vector3 targetPosition;

    private bool isMoving = false;

    //Asia Code for Energy
    public int maxHealth = 100;
    public int currentEnergy;
    public EnergyBar energyBar;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        stop = FindObjectsOfType<Stops>();

        //Asia code for energy
        currentEnergy = maxHealth;
        energyBar.SetMaxEnergy(maxHealth);
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
        //Asia code for energy
        //if (GameObject.)
        //{
            TakeDamage(10);
       // }
    }
    // Asia code for energy
    public void TakeDamage(int damage)
    {
        currentEnergy -= damage;
        energyBar.SetEnergy(currentEnergy);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If collided with the stop that has the "Blockade" tag, it will grab that gameobject to be used in the method "Remove Blockade" and change the tag
        if(other.gameObject.CompareTag("Blockade"))
        {
            stopObject = other.gameObject;

            foreach(Stops stop in stop)
            {
                stop.canclick = false;
            }
        }

        // If collided with stops that have people, it will trigger save buttons and the player cannot move
        if (other.gameObject.CompareTag("5 People"))
        {
            UImanager.TriggerSaveButtons();
            UpdateStopsToFalse();

            stopObject = other.gameObject;
            Debug.Log("Save 5 People or leave them to suffer!");
        }
        else if (other.gameObject.CompareTag("10 People"))
        {
            UImanager.TriggerSaveButtons();
            UpdateStopsToFalse();
            stopObject = other.gameObject;
            Debug.Log("Save 10 People or leave them to suffer!");
        }
        else if (other.gameObject.CompareTag("15 People"))
        {
            UImanager.TriggerSaveButtons();
            UpdateStopsToFalse();
            stopObject = other.gameObject;
            Debug.Log("Save 15 People or leave them to suffer!");
        }
        else if (other.gameObject.CompareTag("Rescued"))
        {
            Debug.Log("Already cleared!");
        }

        // if collided with the blockades it will trigger the blockade buttons, can't move, and gets the blockade gameobject, which will be used in the remove blockade method
        if (other.gameObject.CompareTag("Blockade 1"))
        {
            UImanager.TriggerBlockadeButtons();
            UpdateStopsToFalse();
            Blockade = other.gameObject;

            Debug.Log("Remove Blockade or Go Back!");
        } 
        else if (other.gameObject.CompareTag("Blockade 2"))
        {
            UImanager.TriggerBlockadeButtons();
            UpdateStopsToFalse();
            Blockade = other.gameObject;
        } 
        else if (other.gameObject.CompareTag("Blockade 3"))
        {
            UImanager.TriggerBlockadeButtons();
            UpdateStopsToFalse();
            Blockade = other.gameObject;
        }
    }

    // This method makes it so that the player cannot click on a stop
    public void UpdateStopsToFalse()
    {
        foreach (Stops stop in stop)
        {
            stop.canclick = false;
        }
    }

    // This method makes it so that the player can click on a stop
    public void UpdateStopsToTrue()
    {
        foreach (Stops stop in stop)
        {
            stop.canclick = true;
        }
    }

    // If the Rescue is clicked, the stops tag that the player is on will change to "Rescued" and people will be added
    public void RescuePeople()
    {

        if (stopObject.gameObject.CompareTag("5 People"))
        {
            gameManager.CalculateAmountOfPeople(5);
            stopObject.tag = "Rescued";
            Debug.Log("You Rescued 5 People!");
        }
        else if (stopObject.gameObject.CompareTag("10 People"))
        {
            gameManager.CalculateAmountOfPeople(10);
            stopObject.tag = "Rescued";
            Debug.Log("You Rescued 10 People!");
        }
        else if (stopObject.gameObject.CompareTag("15 People"))
        {
            gameManager.CalculateAmountOfPeople(15);
            stopObject.tag = "Rescued";
            Debug.Log("You Rescued 15 People!");
        }
    }

    public void RemoveBlockade()
    {
        if (Blockade.gameObject.CompareTag("Blockade 1"))
        {
            if (gameManager.numPeople >= 5)
            {
                stopObject.tag = "Blockade Removed";
                Blockade.gameObject.tag = "Blockade Removed";
                Blockade.gameObject.SetActive(false);

                Debug.Log("Removed Blockade");
            }
            else
            {
                Debug.Log("You need 5 or more people to remove blockade!");
            }
        }
        else if(Blockade.gameObject.CompareTag("Blockade 2"))
        {
            if(gameManager.numPeople >= 10)
            {
                stopObject.tag = "Blockade Removed";
                Blockade.gameObject.tag = "Blockade Removed";
                Blockade.gameObject.SetActive(false);
                Debug.Log("Removed Blockade");
            }
            else
            {
                Debug.Log("You need 10 or more people to remove blockade!");
            }
        }
        else if(Blockade.gameObject.CompareTag("Blockade 3"))
        {
            if(gameManager.numPeople >= 20)
            {
                stopObject.tag = "Blockade Removed";
                Blockade.gameObject.tag = "Blockade Removed";
                Blockade.gameObject.SetActive(false);
                Debug.Log("Removed Blockade");
            }
            else
            {
                Debug.Log("You need 20 or more people to remove blockade!");
            }
        }
    }

}
