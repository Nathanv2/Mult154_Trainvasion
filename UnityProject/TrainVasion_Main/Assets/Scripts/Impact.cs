using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    public AudioManager1 audioManager1;

    private void Awake()
    {
        audioManager1 = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager1>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            audioManager1.PlaySFX(audioManager1.Impact);
        }
    }

}
