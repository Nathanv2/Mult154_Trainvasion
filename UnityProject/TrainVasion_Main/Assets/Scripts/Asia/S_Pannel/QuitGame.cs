using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitGameOption()
    {
        Debug.Log("Qutting game...");
        Application.Quit();
    }
}
