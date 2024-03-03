using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySlam : BaseAttack
{
   public HeavySlam()
    {
        attackName = "Heavy Slam";
        attackDescription = "Deliver a devastating slam to your foes";
        attackDamage = 25f;
        attackCost = 10f;
    }
}
