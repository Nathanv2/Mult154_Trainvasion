using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandleTurns
{
    public string Attacker;//name of attacker
    public string Type;
    public GameObject AttackersGameObject;//Who made the attack
    public GameObject attackersTarget;//who he attacks

    //which attack is performed
    public BaseAttack choosenAttack;
}
