using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroScript : BaseClass
{
    //Healing??
    public bool hasHealingCapabilities = false;

    //Stats
    public int stamina;
    public int intellect;
    public int dexterity;
    public int agility;

    public List<BaseAttack> SpecialAttacks = new List<BaseAttack>();
}
