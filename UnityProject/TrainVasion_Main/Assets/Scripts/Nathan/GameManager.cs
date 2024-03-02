using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numPeople;
    // Start is called before the first frame update
    void Start()
    {
        numPeople = 0;
    }

    public void CalculateAmountOfPeople(int rescuePeople)
    {
        if (rescuePeople == 5)
        {
            numPeople = numPeople + 5;
        }
        else if (rescuePeople == 10)
        {
            numPeople = numPeople + 10;
        }
        else if(rescuePeople == 15)
        {
            numPeople = numPeople + 15;
        }
    }
}
