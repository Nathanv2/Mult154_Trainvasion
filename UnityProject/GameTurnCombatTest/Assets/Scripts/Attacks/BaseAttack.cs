using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BaseAttack : MonoBehaviour
{
    public string attackName;//self-explanatory
    public string attackDescription;//describes attack
    public float attackDamage;//Base damage + the stats of said character
    public float attackCost;//special attacks can use energy to unleash powerful attacks

    
}
