using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySource : MonoBehaviour
{
    public EnergyBar energyBar;
    public int energy = 5;


    private void Update()
    {
        if(energyBar == null)
        {
            
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            energyBar.slider.value += 10;
            Debug.Log("Added 10 energy!");
        }
    }
}
