using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnergySystem
{
    public event EventHandler OnEnergyChanged;

    private int energy;
    private int energyMax;

    public EnergySystem(int energyMax)
    {
        this.energyMax = energyMax;
        energy = energyMax;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public float GetEnergyPercent()
    {
        return (float)energy / energyMax;
    }

    public void Damage(int damageAmount)
    {
        energy -= damageAmount;
        if (energy < 0) energy = 0;
        if (OnEnergyChanged != null) OnEnergyChanged(this, EventArgs.Empty);
    }

    public void Heal (int eneryAmount)
    {
        energy += eneryAmount;
        if (energy > energyMax) energy = energyMax;
        if (OnEnergyChanged != null) OnEnergyChanged(this, EventArgs.Empty);
    }

}
