using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStab : BaseAttack
{
    public QuickStab()
    {
        attackName = "Quick Stab";
        attackDescription = "basic knife stab";
        attackDamage = 7f;
        attackCost = 0;
        //AudioManager.PlaySFX(AudioManager.BarricadeDestruction);
    }
}
