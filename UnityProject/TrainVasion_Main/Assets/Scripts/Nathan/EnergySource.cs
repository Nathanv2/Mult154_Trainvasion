using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySource : MonoBehaviour
{
    public EnergyBar energyBar;
    public int energy = 5;


    private void Update()
    {
        if (energyBar == null)
        {
            energyBar = FindObjectOfType<EnergyBar>();
        }     
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            energyBar.slider.value += 10;
            Destroy(gameObject);
            Debug.Log("Added 10 energy!");
        }
    }
}
