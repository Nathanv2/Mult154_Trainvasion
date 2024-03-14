using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandleTurns
{

    //this is for when in battle

    public string Attacker;//name of attacker
    public string Type;
    public GameObject AttackersGameObject;//Who made the attack
    public GameObject attackersTarget;//who he attacks

    //which attack is performed
    public BaseAttack choosenAttack;

    //When moving inside of the main game
    public string Stop;
    public string LevelOfStop;
    public string NumberOfEnemies;
    public string NumberOfHeroes;
    public GameObject StopGameObject;
    
}
