using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class AsyncLoader : MonoBehaviour
{
    [Header("Menu Screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;

    public GameObject mainMenuCanvas;
    public Canvas mainmenucanvasComponent;

    public GameObject MainCamera;
    public AudioManager audioManager;

    private bool LoadedScreen = false;

    public void Update()
    {
        if (loadingSlider.value == 2)
        {
            SceneManager.LoadScene("Trainvasion", LoadSceneMode.Additive);
            loadingSlider.enabled = false; loadingScreen.SetActive(false);
            LoadedScreen = false;
            loadingSlider.value = 0;
            MainCamera.gameObject.SetActive(false);
            audioManager.backgroundAudio.Stop();
        }

        mainMenuCanvas = GameObject.Find("MainMenu");

        if (mainmenucanvasComponent == null)
        {
            mainmenucanvasComponent = mainMenuCanvas.GetComponent<Canvas>();
        }
    }

    public void FixedUpdate()
    {
        if(LoadedScreen)
        {
            loadingSlider.value = loadingSlider.value + 0.01f;
            Debug.Log(loadingSlider.value);
        }
    }

    public void EnableMainMenuCanvas()
    {
        mainmenucanvasComponent.enabled = true;
    }

    public void DisableMainMenuCanvas()
    {
        mainmenucanvasComponent.enabled = false;
        loadingScreen.SetActive(true);
        LoadedScreen = true;
    }
}
