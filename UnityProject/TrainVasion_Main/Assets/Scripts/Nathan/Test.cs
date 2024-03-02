using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject mainCamera;
    public UIManager uiManager;
    public Button backButton;

    public void Update()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    public void UnloadCombatScene()
    {
        mainCamera.SetActive(false);
        backButton.gameObject.SetActive(false);
        uiManager.peopleText.gameObject.SetActive(true);

        playerController = FindObjectOfType<PlayerController>();
        playerController.UpdateStopsToTrue();

        SceneManager.UnloadSceneAsync("Test");
        Debug.Log("YOU WON!");
    }
}
