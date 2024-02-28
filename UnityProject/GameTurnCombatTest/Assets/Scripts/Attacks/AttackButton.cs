using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public BaseAttack specialAttackToPerform;

    public void CastSpecialAttack()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().Input4(specialAttackToPerform);
    }
}
