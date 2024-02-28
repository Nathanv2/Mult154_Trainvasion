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
    public Button backButton;

    public void UnloadCombatScene()
    {
        mainCamera.SetActive(false);
        backButton.gameObject.SetActive(false);

        playerController = FindObjectOfType<PlayerController>();
        playerController.UpdateStopsToTrue();

        SceneManager.UnloadSceneAsync("Test");
        Debug.Log("Unloaded Combat Scene!");
        Debug.Log("YOU WON!");
    }
}
