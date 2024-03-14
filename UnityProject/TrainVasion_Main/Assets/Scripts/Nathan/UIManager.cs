using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameManager gameManager;
    public Raycasting rayCast;

    public Button saveButton;
    public Button skipButton;
    public Button removeBlockade;
    public Button goBack;

    public TextMeshProUGUI peopleText;

    void Start()
    {

    }

    private void Update()
    {
        peopleText.text = "People: " + gameManager.numPeople;
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

        //SceneManager.LoadScene("Test");
        Debug.Log("You chose to save the people!");
    }

    public void ArrowButtons(GameObject other)
    {
        if(other.gameObject.CompareTag("Forward Arrow") && playerController.canMove)
        {
            rayCast.ActivateMovement();
        }
        else if(other.gameObject.CompareTag("Left Arrow") && playerController.canMove)
        {
            playerController.PlayerMovement(0, 0);
        }
        else if(other.gameObject.CompareTag("Right Arrow") && playerController.canMove)
        {
            playerController.PlayerMovement(1, 1);
        }
        else if(other.gameObject.CompareTag("Backward Arrow"))
        {

        }
    }
}
