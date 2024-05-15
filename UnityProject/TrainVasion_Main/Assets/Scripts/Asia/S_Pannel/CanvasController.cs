using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject optionCanvas;
    public Canvas optioncanvasComponent;
    public MainMenuCanvasController settingscanvasComponent;

    private void Update()
    {
        optionCanvas = GameObject.Find("Options/restart(Asia)");

        if (optioncanvasComponent == null)
        {
            optioncanvasComponent = optionCanvas.GetComponent<Canvas>();
        }

        if (settingscanvasComponent == null)
        {
            settingscanvasComponent = FindObjectOfType<MainMenuCanvasController>();
        }
    }

    public void EnableSettingsCanvas()
    {
        settingscanvasComponent.EnableSettingsCanvas();
    }

    public void DisableSettingsCanvas()
    {
        settingscanvasComponent.DisableSettingsCanvas();
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
