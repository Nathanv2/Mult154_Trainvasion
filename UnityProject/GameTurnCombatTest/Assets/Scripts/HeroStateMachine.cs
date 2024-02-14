using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour
{
    public HeroScript hero;

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
    public Image prgressBar;

    private void Start()
    {
        currentState = TurnState.PROCESSING; 
    }


    private void Update()
    {
        switch (currentState)
        {
            case (TurnState.PROCESSING):
                UpdateProgressBar();
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
        float calc_cooldown = cur_cooldown / max_cooldown;
        prgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), prgressBar.transform.localScale.y, prgressBar.transform.localScale.z);
        if(cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.ADDTOLIST;
        }

    }
}
