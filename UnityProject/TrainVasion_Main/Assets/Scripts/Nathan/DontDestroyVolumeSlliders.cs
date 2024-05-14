using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroyVolumeSlliders : MonoBehaviour
{
    public static DontDestroyVolumeSlliders instance;
    private void Awake()
    {
        Debug.Log("Awake method called.");

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed duplicate instance.");
        }

        DontDestroyOnLoad(gameObject);
        Debug.Log("Object set to DontDestroyOnLoad.");
    }
}
