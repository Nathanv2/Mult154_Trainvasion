using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroScript : MonoBehaviour
{
    public string hero;

    //base Attributes
    public float baseHealth;
    public float currentHealth;

    public float baseMp;
    public float currentMp;

    //Stats
    public int stamina;
    public int intellect;
    public int dexterity;
    public int agility;

}
