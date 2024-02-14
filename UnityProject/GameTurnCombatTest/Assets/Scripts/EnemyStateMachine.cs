using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyScript enemy;

    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }

    public TurnState currentState;

    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;

    private void Start()
    {
        currentState = TurnState.PROCESSING;
    }

    private void Update()
    {
        switch (currentState)
        {
            case (TurnState.PROCESSING):
                
                break;

            case (TurnState.ADDTOLIST):

                break;

            case (TurnState.WAITING):

                break;

            case (TurnState.SELECTING):

                break;

            case (TurnState.ACTION):

                break;

            case (TurnState.DEAD):

                break;
        }
    }

    void UpdateProgressBar()
    {
        cur_cooldown = cur_cooldown + Time.deltaTime;
        
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.ADDTOLIST;
        }

    }
}
