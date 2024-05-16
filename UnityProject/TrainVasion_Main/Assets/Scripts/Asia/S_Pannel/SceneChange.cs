using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public AsyncLoader mainmenuCanvas;
    public AudioManager audioManager;
    public GameManager gameManager;

    void Update()
    {
        if (mainmenuCanvas == null)
        {
            mainmenuCanvas = FindObjectOfType<AsyncLoader>();
        }

        audioManager = FindAnyObjectByType<AudioManager>();
        gameManager = FindAnyObjectByType<GameManager>();
          
    }

    public void ChangeScene()
    {
        SceneManager.UnloadSceneAsync("Trainvasion");
        mainmenuCanvas.EnableMainMenuCanvas();
        mainmenuCanvas.MainCamera.SetActive(true);
        audioManager.mainMenuAudio.Play();
        gameManager.isOnMainGame = false;
    }
}
