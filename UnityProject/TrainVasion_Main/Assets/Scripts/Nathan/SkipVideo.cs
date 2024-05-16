using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{

    public void Skip()
    {
        SceneManager.UnloadSceneAsync("NewsReport");
        SceneManager.LoadScene("UFOVideo", LoadSceneMode.Additive);
    }
}
