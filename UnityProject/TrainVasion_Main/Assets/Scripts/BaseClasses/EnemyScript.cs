using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class EnemyScript : BaseClass
{
   

    public enum Type
    {
        GRASS,
        FIRE,
        WATER,
        ELECTRIC
    }

    public int stamina;
    public int intellect;
    public int dexterity;
    public int agility;

    public Type EnemyType;

    

}
