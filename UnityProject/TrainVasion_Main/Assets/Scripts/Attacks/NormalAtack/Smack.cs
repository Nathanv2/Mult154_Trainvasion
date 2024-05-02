using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smack : BaseAttack
{
    public Smack()
    {
        attackName = "Smack";
        attackDescription = "Just a smack";
        attackDamage = 5f;
        attackCost = 0;
        //AudioManager.PlaySFX(AudioManager.BarricadeDestruction);
    }
}
