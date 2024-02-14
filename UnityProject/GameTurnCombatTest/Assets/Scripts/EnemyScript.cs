using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class EnemyScript : MonoBehaviour
{
    public string nameEnemy;

    public enum Type
    {
        GRASS,
        FIRE,
        WATER,
        ELECTRIC
    }

    public Type EnemyType;

    //base Attributes
    public float baseHealth;
    public float currentHealth;

    public float baseMp;
    public float currentMp;

    public float baseAttack;
    public float currentAttack;
    public float baseDefense;
    public float currentDefense;


}
