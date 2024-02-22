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

    public Type EnemyType;

    

}
