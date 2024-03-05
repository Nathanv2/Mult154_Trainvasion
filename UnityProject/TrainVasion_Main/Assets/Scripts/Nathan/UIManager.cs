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
    public Stops[] stop;

    public Button saveButton;
    public Button skipButton;
    public Button removeBlockade;
    public Button goBack;

    public TextMeshProUGUI peopleText;

    void Start()
    {
        stop = FindObjectsOfType<Stops>();
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
        playerController.UpdateStopsToTrue();
        Debug.Log("You chose to leave the people to suffer!");
    }

    public void RemoveBlockadeButton()
    {
        removeBlockade.gameObject.SetActive(false);
        goBack.gameObject.SetActive(false);
        playerController.UpdateStopsToTrue();
    }

    public void GoBackButton()
    {
        removeBlockade.gameObject.SetActive(false);
        goBack.gameObject.SetActive(false);
        playerController.UpdateStopsToTrue();
        Debug.Log("You chose to go back!");
    }


    //Angel's working on this (transitions to combat scene)
    public void RescueButton()
    {
        saveButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        peopleText.gameObject.SetActive(false);

        SceneManager.LoadScene("SampleScene");
        Debug.Log("You chose to save the people!");
    }
}
