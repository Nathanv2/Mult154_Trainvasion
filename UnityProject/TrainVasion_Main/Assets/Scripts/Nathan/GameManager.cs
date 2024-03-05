using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int numPeople;


    //Angel's Code (Enum Stuff/Game States)
    //This will dictate the flow of the game
    public enum GameStates
    {
        IDLE,
        MOVETOSTOP,
        MOVED,
        CHOOSE,
        RESCUED,
        SKIP,
        WINGAME,
        LOSEGAME
    }
    public GameStates statesOfGame;

    //creates a new list where gameManager will read from to see what is happening and what to do
    public List<HandleTurns> TurnsOfMainGame = new List<HandleTurns>();

    //Angel's code (awake is called, its faster than start + wont destroy sceneManager)
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        numPeople = 0;

        statesOfGame = GameStates.IDLE;
    }


    public void Update()
    {

        //Angel's code(switch cases of the game)
        switch(statesOfGame)
        {
            case(GameStates.IDLE):

                //This is idle state AKA player is doing nothing, idle will transition quickly to movetostop state
                if(TurnsOfMainGame.Count > 0)
                {

                }

            break;

            case (GameStates.MOVETOSTOP):

                //player will get the option to move to tiles where the whole player controller function will take place

                //once player moves will transition to choose option state which is self explanatory

            break;

            case (GameStates.MOVED):

                //when moved update bar stuff Asia's stuff will be here

            break;

            case (GameStates.CHOOSE):

                //GUI will activate allowing player to choose either skip or save

                //when saving switch to rescued state 

                //if skip occurs, switch to skip state

            break;

            case (GameStates.RESCUED):

                //this will change scene to combat scene heroes and enemies will be instantiated depending on the stats of the player

            break;

            case (GameStates.SKIP):

                //skip will move player back to idle where he can decide what to do

            break;

            case (GameStates.WINGAME):

                //if player reaches end game will end on a win

            break;

            case (GameStates.LOSEGAME):

                //this will change scene to epic cinematic where we tragically loose

            break;


        }
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
