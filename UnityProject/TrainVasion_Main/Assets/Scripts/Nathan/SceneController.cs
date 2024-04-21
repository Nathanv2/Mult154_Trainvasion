using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableAllObjectsInCurrentScene()
    {
        // Get all root objects in the current scene
        GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        // Iterate through each root object and deactivate them
        foreach (GameObject obj in rootObjects)
        {
            obj.SetActive(false);
        }
    }
}
