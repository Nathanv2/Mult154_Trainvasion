using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuCanvasController : MonoBehaviour
{
    public GameObject settingsCanvas;
    public Canvas settingsCanvasComponent;


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
