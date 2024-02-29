using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    private EnergySystem energySystem;

    public void Setup(EnergySystem energySystem)
    {
        this.energySystem = energySystem;

        energySystem.OnEnergyChanged += EnergySystem_OnEnergyChanged;
    }

    private void EnergySystem_OnEnergyChanged(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(energySystem.GetEnergyPercent(), 1);
    }


    private void Update()
    {
        //transform.Find("Bar").localScale = new Vector3(energySystem.GetEnergyPercent(), 1);
    }

}
