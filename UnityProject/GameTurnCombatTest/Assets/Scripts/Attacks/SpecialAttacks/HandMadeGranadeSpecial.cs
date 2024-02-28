using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMadeGranadeSpecial : BaseAttack
{
    public HandMadeGranadeSpecial()
    {
        attackName = "Handmadde Granade";
        attackDescription = "throw a granade that you made to an enemy";
        attackDamage = 30f;
        attackCost = 15f;
    }
}
