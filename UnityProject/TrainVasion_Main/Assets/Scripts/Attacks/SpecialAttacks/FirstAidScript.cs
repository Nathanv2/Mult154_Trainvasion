using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidScript : BaseAttack
{
    public FirstAidScript()
    {
        healName = "First Aid";
        healDescription = "Apply Basic Aid";
        healAmount = 25;
        healCost = 25;
    }
}
