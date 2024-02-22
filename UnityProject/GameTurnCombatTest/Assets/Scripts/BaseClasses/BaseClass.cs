using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass
{
    public string theName;

    //base Attributes
    public float baseHealth;
    public float currentHealth;

    public float baseMp;
    public float currentMp;

    public float baseAttack;
    public float currentAttack;
    public float baseDefense;
    public float currentDefense;

    public List<BaseAttack> attacks = new List<BaseAttack>();
}
