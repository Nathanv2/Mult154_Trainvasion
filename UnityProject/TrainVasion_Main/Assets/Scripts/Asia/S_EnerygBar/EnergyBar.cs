using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private EnergySystem energySystem;

    public Slider slider;
    public int currentEnergy = 100;

    public GameManager GM;

    public void Start()
    {
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void SetMaxEnergy(int energy)
    {
        slider.maxValue = 100;
        slider.value = energy;
    }


    public void SetEnergy()
    {
        slider.value = currentEnergy;
    }



    /*public void Setup(EnergySystem energySystem)
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
    }*/

}
