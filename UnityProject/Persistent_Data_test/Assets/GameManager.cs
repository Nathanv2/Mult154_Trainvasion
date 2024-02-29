using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject mainCharacter;

    public string data = "YIPPE I CHANGED SCENES WITH PERSISTENT DATA";

    public string sceneToLoad;
    public string lastScene;

    private void Awake()
    {
        //checks if intance exists
        if(instance == null)
        {
            instance = this;
        }
        //if an intance of the gameManager already exists on a scene destroy it
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        //wont be destroyed between changing scenes
        DontDestroyOnLoad(gameObject);

        //check if there's a player and sets it so it is not destroyable
        DontDestroyOnLoad(gameObject);
        if (!GameObject.FindGameObjectWithTag("MC"))
        {
            GameObject MainGuy = Instantiate(mainCharacter, Vector3.zero, Quaternion.identity);
            MainGuy.name = "Intantiated Main Guy";
        }
        
    }

    private void Update()
    {
        //place timer to change scenes
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeScene();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ReloadScene();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(lastScene);
    }
}
