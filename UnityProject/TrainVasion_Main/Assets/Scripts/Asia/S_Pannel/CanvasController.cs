using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject canvas;
    
    public void OpenCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
    }

    public void CloseCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }
}
