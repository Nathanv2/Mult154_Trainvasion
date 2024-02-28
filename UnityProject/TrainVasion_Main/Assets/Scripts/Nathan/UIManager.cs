using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public Stops[] stop;

    public Button saveButton;
    public Button skipButton;
    public Button removeBlockade;
    public Button goBack;

    void Start()
    {
        stop = FindObjectsOfType<Stops>();
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

    public void SetButtonsFalse()
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
        Debug.Log("You removed the blockade!");
    }

    public void GoBackButton()
    {
        removeBlockade.gameObject.SetActive(false);
        goBack.gameObject.SetActive(false);
        playerController.UpdateStopsToTrue();
        Debug.Log("You did not have enough people to remove the blockade!");
    }

    public void LoadCombatScene()
    {
        saveButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        SceneManager.LoadScene("Test", LoadSceneMode.Additive);
        Debug.Log("You chose to save the people!");
        Debug.Log("Loaded Combat Scene!");
    }
}
