using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienCollision : MonoBehaviour
{
    AudioManager audioManager;

    public void Update()
    {
        if (audioManager == null)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            //AudioManager.PlaySFX(AudioManager.destruction);
            audioManager.aliencolliderAudioComponent.Play();
            SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Exploration");
        }
    }
}
