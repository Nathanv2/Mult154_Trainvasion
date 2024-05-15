using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuCanvasController : MonoBehaviour
{
    public static MainMenuCanvasController instance;
    public GameObject settingsCanvas;
    public Canvas settingsCanvasComponent;


    private void Awake()
    {
        //checks if intance exists
        if (instance == null)
        {
            instance = this;
        }
        //if an intance of the gameManager already exists on a scene destroy it
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //wont be destroyed between changing scenes
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        settingsCanvas = GameObject.Find("OptionsMenuCanvas");
        if (settingsCanvasComponent == null)
        {
            settingsCanvasComponent = settingsCanvas.GetComponent<Canvas>();
        }
    }

    public void EnableSettingsCanvas()
    {
        settingsCanvasComponent.enabled = true;
    }

    public void DisableSettingsCanvas()
    {
        settingsCanvasComponent.enabled = false;
    }
}
