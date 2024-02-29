using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numPeople2;
    // Start is called before the first frame update
    void Start()
    {
        numPeople2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateAmountOfPeople(int numPeople)
    {
        if (numPeople == 5)
        {
            numPeople2 = numPeople2 + 5;
            Debug.Log(numPeople2);
        }
        else if (numPeople == 10)
        {
            numPeople2 = numPeople2 + 10;
            Debug.Log(numPeople2);
        }
        else if(numPeople == 15)
        {
            numPeople2 = numPeople2 + 15;
            Debug.Log(numPeople2);
        }
    }
}
