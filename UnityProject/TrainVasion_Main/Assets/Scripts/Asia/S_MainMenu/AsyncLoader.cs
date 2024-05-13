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

    public GameObject MainCamera;

    private bool LoadedScreen = false;

    public void LoadLevelBtn(string levelToLoad)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        LoadedScreen = true;
    }

    public void Update()
    {
        if (loadingSlider.value == 2)
        {
            SceneManager.LoadScene("Trainvasion", LoadSceneMode.Additive);
            loadingSlider.enabled = false; loadingScreen.SetActive(false);
            LoadedScreen = false;
            loadingSlider.value = 1;
            MainCamera.gameObject.SetActive(false);
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
}
