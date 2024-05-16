using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public AsyncLoader mainmenuCanvas;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainmenuCanvas == null)
        {
            mainmenuCanvas = FindObjectOfType<AsyncLoader>();
        }

        audioManager = FindAnyObjectByType<AudioManager>();
          
    }

    public void ChangeScene()
    {
        SceneManager.UnloadSceneAsync("Trainvasion");
        mainmenuCanvas.EnableMainMenuCanvas();
        mainmenuCanvas.MainCamera.SetActive(true);
        audioManager.mainMenuAudio.Play();
    }
}
