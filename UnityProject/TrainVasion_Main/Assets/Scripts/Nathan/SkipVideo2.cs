using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo2 : MonoBehaviour
{
    public void Skip()
    {
        SceneManager.UnloadSceneAsync("UFOVideo");
        SceneManager.LoadScene("Trainvasion", LoadSceneMode.Additive);
    }
}
