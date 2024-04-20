using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    //public GameManager gameManager;
    public Raycasting rayCast;
    public Rotate rotatePlayer;

    public Button saveButton;
    public Button skipButton;
    public Button removeBlockade;
    public Button goBack;
    public EnergyBar energyBar;

    private float buttonCooldown = 2f;
    private bool canClick = true;

    public TextMeshProUGUI peopleText;
    public TextMeshProUGUI gameOverText;

    public GameManager GM;

    public void Start()
    {
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        energyBar = GameObject.Find("EnergyBarCanvas").GetComponent<EnergyBar>();
    }



    private void Update()
    {
        peopleText.text = "People: " + GM.numPeople;
    }

    public void TriggerSaveButtons()
    {
        saveButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
    }

    public void TriggerBlockadeButtons()
    {
        goBack.gameObject.SetActive(true);
        removeBlockade.gameObject.SetActive(true);
    }

    public void SkipButton()
    {
        saveButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        playerController.canMove = true;
        canClick = true;
        Debug.Log("You chose to leave the people to suffer!");
    }

    public void RemoveBlockadeButton()
    {
        removeBlockade.gameObject.SetActive(false);
        goBack.gameObject.SetActive(false);
        playerController.canMove = true;
    }

    public void GoBackButton()
    {
        removeBlockade.gameObject.SetActive(false);
        goBack.gameObject.SetActive(false);
        playerController.canMove = true;
        Debug.Log("You chose to go back!");
    }

    //Angel's working on this (transitions to combat scene)
    public void RescueButton()
    {
        saveButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        peopleText.gameObject.SetActive(true);
        playerController.canMove = true;
        canClick = true;

        //SceneManager.LoadScene("Test");
        SceneManager.LoadScene("Exploration");
        Debug.Log("You chose to save the people!");
    }

    public void StartCombat()
    {
        SceneManager.LoadScene("Combat");
    }

    public void ArrowButtons(GameObject other)
    {
        if(playerController.canMove)
        {
            if (other.gameObject.CompareTag("Forward Arrow"))
            {
                rayCast.ActivateMovement();
            }
            else if (other.gameObject.CompareTag("Left Arrow") && canClick)
            {
                rayCast.RotateRay(1, 1);
                rotatePlayer.RotatePlayerLeft();
                StartCoroutine(ButtonCooldown());
            }
            else if (other.gameObject.CompareTag("Right Arrow") && canClick)
            {
                rayCast.RotateRay(0, 0);
                rotatePlayer.RotatePlayerRight();
                StartCoroutine(ButtonCooldown());
            }
            else if (other.gameObject.CompareTag("Backward Arrow"))
            {

            }
        }
    }
    public void GameOver()
    {
        if (energyBar.slider.value <= 0)
        {
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);
            SkipButton();
            Debug.Log("GAME OVER");
        }
    }

    IEnumerator ButtonCooldown()
    {
        canClick = false;

        yield return new WaitForSeconds(buttonCooldown);

        canClick = true;
    }
}
