using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienCollision : MonoBehaviour
{
    AudioManager AudioManager;

    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Alien"){
            AudioManager.PlaySFX(AudioManager.BarricadeDestruction);
            SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Exploration");
        }
    }
}
