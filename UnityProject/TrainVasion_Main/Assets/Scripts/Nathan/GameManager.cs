using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int numPeople;
    public EnergyBar energyBar;
    public UIManager uiManager;


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

        FindEnergy();


    }

    private void Update()
    {
        GameOver();
    }

    public void CalculateAmountOfPeople(int rescuePeople)
    {
        if (rescuePeople == 1)
        {
            numPeople = numPeople + 1;
        }
        else if (rescuePeople == 5)
        {
            numPeople = numPeople + 5;
        }
        else if(rescuePeople == 10)
        {
            numPeople = numPeople + 10;
        }
    }

    public void GameOver()
    {
        if(energyBar.slider.value <= 0)
        {
            Time.timeScale = 0;
            uiManager.gameOverText.gameObject.SetActive(true);
            uiManager.SkipButton();
            Debug.Log("GAME OVER");
        }
    }

    public void FindEnergy()
    {
        energyBar = GameObject.Find("EnergyBarCanvas").GetComponent<EnergyBar>();
    }

    public void LoadTrainVasionScene()
    {
        SceneManager.LoadScene("Trainvasion");
    }
}
