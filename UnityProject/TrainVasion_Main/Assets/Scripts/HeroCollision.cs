using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact2 : MonoBehaviour
{
    public AudioManager AudioManager;

    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            //AudioManager.PlaySFX(AudioManager.streetcar);
        }
    }
}
