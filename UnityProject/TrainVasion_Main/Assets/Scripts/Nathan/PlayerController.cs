using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public GameManager gameManager; (angel changed this because it will cause problems with the game transitions between scenes since it's trying to find the object from the project browser and not in game)
    private GameManager GM;
    public UIManager UImanager;
    private Rigidbody rbPlayer;
    private GameObject Player;
    public Collider test;
    private GameObject stopObject;
    public GameObject Blockade;
    private Raycasting raycast;

    public float movementSpeed = 1f;
    private Vector3 targetPosition;

    public bool isMoving = false;
    public bool canMove;

    //Asia Code for Energy
    public int maxHealth = 100;
    public int damage = 10;
    public int currentEnergy;
    public EnergyBar energyBar;
    public GameObject Map;

    //Angel's code variables

    public AudioSource audioSource;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        raycast = GetComponent<Raycasting>();
        canMove = true;

        //Asia code for energy
        currentEnergy = maxHealth;
        energyBar.SetMaxEnergy(maxHealth);

        //Angel's start

        //this finds the object from inside the game
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Map.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Map.SetActive(false);
        }
        
        /*if(Input.GetKeyUp(KeyCode.M))
        {
            Map.SetActive(false);
        }*/
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            MoveTowardsTargetPosition();
        }
    }

    public void Transition(Vector3 NextStop)
    {
        targetPosition = NextStop;
        isMoving = true;
        audioSource.Play();
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
    // Asia code for energy
    public void TakeDamage()
    {
        energyBar.slider.value -= 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        //BlockadeStuff
        if (other.CompareTag("BlockadeTrigger"))
        {
            //GM.blockadeAhead = true;
            GM.blockades.Add(other.transform.parent.gameObject);
            BlockadeHandler blockadeHandler = other.GetComponentInParent<BlockadeHandler>();
            int blockadePrice = blockadeHandler.peopleRequired;
            UImanager.peopleForBlockade = blockadePrice;
        }
        // If collided with the stop that has the "Blockade" tag, it will grab that gameobject to be used in the method "Remove Blockade" and change the tag
        if (other.gameObject.CompareTag("Blockade"))
        {
            stopObject = other.gameObject;
            canMove = false;
            TakeDamage();
        }

        // If collided with stops that have people, it will trigger save buttons and the player cannot move
        if (other.gameObject.CompareTag("1 People") || other.gameObject.CompareTag("5 People") || other.gameObject.CompareTag("10 People"))
        {
            UImanager.TriggerSaveButtons();
            canMove = false;
            stopObject = other.gameObject;
            TakeDamage();
            transform.position = new Vector3 (targetPosition.x, 5, targetPosition.z);

            Debug.Log("Rescue the people or leave them to suffer!");
        }
        else if (other.gameObject.CompareTag("Rescued") || other.gameObject.CompareTag("Blockade Removed"))
        {
            TakeDamage();
            Debug.Log("Already cleared!");
        }

        // if collided with the blockades it will trigger the blockade buttons, can't move, and gets the blockade gameobject, which will be used in the remove blockade method
        if (other.gameObject.CompareTag("Blockade 1") || other.gameObject.CompareTag("Blockade 2") || other.gameObject.CompareTag("Blockade 3"))
        {
            canMove = false;
            UImanager.TriggerBlockadeButtons();
            Blockade = other.gameObject;

            Debug.Log("Remove Blockade or Go Back!");
        } 

        if(other.gameObject.CompareTag("The End"))
        {
            GM.Victory();
            UImanager.VictoryText();
        }
    }

    // If the Rescue is clicked, the stops tag that the player is on will change to "Rescued" and people will be added
    public void RescuePeople()
    {

        if (stopObject.gameObject.CompareTag("1 People"))
        {
            GM.CalculateAmountOfPeople(1);
            stopObject.tag = "Rescued";
            Debug.Log("You Rescued 1 People!");
        }
        else if (stopObject.gameObject.CompareTag("5 People"))
        {
            GM.CalculateAmountOfPeople(5);
            stopObject.tag = "Rescued";
            Debug.Log("You Rescued 5 People!");
        }
        else if (stopObject.gameObject.CompareTag("10 People"))
        {
            GM.CalculateAmountOfPeople(10);
            stopObject.tag = "Rescued";
            Debug.Log("You Rescued 10 People!");
        }
    }

    public void RemoveBlockade()
    {
        if (Blockade.gameObject.CompareTag("Blockade 1") || Blockade.gameObject.CompareTag("Blockade 2") || Blockade.gameObject.CompareTag("Blockade 3"))
        {
            if (GM.numPeople >= 20 || GM.numPeople >= 45)
            {
                stopObject.tag = "Blockade Removed";
                Blockade.gameObject.tag = "Blockade Removed";
                Blockade.gameObject.SetActive(false);
                Debug.Log("Removed Blockade");
                audioSource.Play();
            }
            else
            {
                Debug.Log("You did not meet the required amount of people to remove the blockade!");
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RedZone"))
        {
            GM.isOnRed = true;
            GM.isOnYellow = false;
            GM.isOnBlue = false;
        }
     
        if (other.CompareTag("YellowZone"))
        {
            GM.isOnYellow = true;
            GM.isOnRed = false;
            GM.isOnBlue = false;
        }
        if (other.CompareTag("BlueZone"))
        {
            GM.isOnBlue = true; 
            GM.isOnYellow = false;
            GM.isOnRed = false;
        }
        if (other.CompareTag("BlockadeTrigger"))
        {
            GM.blockadeAhead = true;
        }
       
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlockadeTrigger"))
        {
            GM.BlockadeTrigger(false);
            UImanager.blockadeMenu.SetActive(false);
            UImanager.blockadeFail.SetActive(false);
        }
    }
}
