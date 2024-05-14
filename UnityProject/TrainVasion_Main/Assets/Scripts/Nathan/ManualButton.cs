using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManualButton : MonoBehaviour
{
    public GameObject manualCanvas;
    public GameObject page1Canvas;
    public GameObject page2Canvas;
    public GameObject page3Canvas;
    public GameObject page4Canvas;

    public Canvas manualCanvasComponent;
    public Canvas page1CanvasComponent;
    public Canvas page2CanvasComponent;
    public Canvas page3CanvasComponent;
    public Canvas page4CanvasComponent;

    public void Update()
    {
        manualCanvas = GameObject.Find("Manual Canvas(Asia)");
        page1Canvas = GameObject.Find("Page 1 Canvas");
        page2Canvas = GameObject.Find("Page 2 Canvas");
        page3Canvas = GameObject.Find("Page 3 Canvas");
        page4Canvas = GameObject.Find("Page 4 Canvas");

        if (manualCanvasComponent == null)
        {
            manualCanvasComponent = manualCanvas.GetComponent<Canvas>();
        }
        else if(page1CanvasComponent == null)
        {
            page1CanvasComponent = page1Canvas.GetComponent<Canvas>();
        }
        else if(page2CanvasComponent == null)
        {
            page2CanvasComponent = page2Canvas.GetComponent<Canvas>();
        }
        else if(page3CanvasComponent == null)
        {
            page3CanvasComponent = page3Canvas.GetComponent<Canvas>();
        }
        else if(page4CanvasComponent == null)
        {
            page4CanvasComponent = page4Canvas.GetComponent<Canvas>();
        }
    }
    public void EnableManualCanvas()
    {
        manualCanvasComponent.enabled = true;
    }

    public void EnablePage1Canvas()
    {
        page1CanvasComponent.enabled = true;
    }

    public void EnablePage2Canvas()
    {
        page2CanvasComponent.enabled = true;
    }

    public void EnablePage3Canvas()
    {
        page3CanvasComponent.enabled = true;
    }

    public void EnablePage4Canvas()
    {
        page4CanvasComponent.enabled = true;
    }

    public void DisableManualCanvas()
    {
        manualCanvasComponent.enabled = false;
    }

    public void DisablePage1Canvas()
    {
        page1CanvasComponent.enabled = false;
    }

    public void DisablePage2Canvas()
    {
        page2CanvasComponent.enabled = false;
    }

    public void DisablePage3Canvas()
    {
        page3CanvasComponent.enabled = false;
    }

    public void DisablePage4Canvas()
    {
        page4CanvasComponent.enabled = false;
    }
}
