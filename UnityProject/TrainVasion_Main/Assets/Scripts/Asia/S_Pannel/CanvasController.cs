using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject optionCanvas;
    public Canvas settingscanvasComponent;
    public Canvas optioncanvasComponent;

    private void Update()
    {
        settingsCanvas = GameObject.Find("OptionMenuCanvas(Asia)");
        optionCanvas = GameObject.Find("Options/restart(Asia)");

        if (settingscanvasComponent == null)
        {
            settingscanvasComponent = settingsCanvas.GetComponent<Canvas>();
        }

        if (optioncanvasComponent == null)
        {
            optioncanvasComponent = optionCanvas.GetComponent<Canvas>();
        }
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
