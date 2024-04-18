using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : BaseAttack
{
    //AudioManager AudioManager;
    private void Awake()
    {
        //AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public Slash()
    {
        attackName = "Slash";
        attackDescription = "basic knife slash";
        attackDamage = 10f;
        attackCost = 0;
        //AudioManager.PlaySFX(AudioManager.BarricadeDestruction);
    }
}
