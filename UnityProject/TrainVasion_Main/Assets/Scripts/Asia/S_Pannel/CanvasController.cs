using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;
    public GameObject settingsCanvas;
    public GameObject optionCanvas;
    public Canvas settingscanvasComponent;
    public Canvas optioncanvasComponent;


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

    void Start()
    {
        settingsCanvas = GameObject.Find("OptionMenu");
        optionCanvas = GameObject.Find("Options/restart(Asia)");
        if (settingsCanvas != null)
        {
            settingscanvasComponent = settingsCanvas.GetComponent<Canvas>();
        }
        
        if(optionCanvas != null)
        {
            optioncanvasComponent = optionCanvas.GetComponent<Canvas>();
        }
    }

    private void Update()
    {
        optionCanvas = GameObject.Find("Options/restart(Asia)");
    }

    public void EnableSettingsCanvas()
    {
        settingscanvasComponent.enabled = true;
    }

    public void DisableSettingsCanvas()
    {
        settingscanvasComponent.enabled = false;
    }

    public void EnableOptionCanvas()
    {
        optioncanvasComponent.enabled = true;
    }

    public void DisableOptionCanvas()
    {
        optioncanvasComponent.enabled = false;
    }
}
