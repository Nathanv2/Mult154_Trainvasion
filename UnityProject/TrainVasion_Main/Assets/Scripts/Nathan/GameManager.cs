using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int numPeople;
    public EnergyBar energyBar;
    public UIManager uiManager;
    public GameObject player;

    //ZoneColliderStuff

    public bool isOnRed;
    public bool isOnYellow;
    public bool isOnBlue;

    public int enemiesToSpawn;

    //Angel's code (awake is called, its faster than start + wont destroy sceneManager)
    private void Awake()
    {
        //checks if intance exists
        if (instance == null)
        {
            instance = this;
        }
        //if an intance of the gameManager already exists on a scene destroy it
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //wont be destroyed between changing scenes
        DontDestroyOnLoad(gameObject);

        //check if there's a player and sets it so it is not destroyable
        DontDestroyOnLoad(gameObject);
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject MainGuy = Instantiate(player, Vector3.zero, Quaternion.identity);
            MainGuy.name = "Intantiated player";
        }

    }

    void Start()
    {
        

        numPeople = 0;
        //FindStuff();
        
    }

    private void Update()
    {
        GameOver();
        CalculateEnemies();

        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        else if(energyBar == null)
        {
            energyBar = FindObjectOfType<EnergyBar>();
        }
        else if(player == null)
        {
            player = GameObject.Find("Player");
        }
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
        if (energyBar.slider.value <= 0)
        {
            Time.timeScale = 0;
            uiManager.gameOverText.gameObject.SetActive(true);
            uiManager.SkipButton();
            Debug.Log("GAME OVER");
        }
    }

    public void FindStuff()
    {
        energyBar = GameObject.Find("EnergyBarCanvas").GetComponent<EnergyBar>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    public void LoadTrainVasionScene()
    {
        SceneManager.LoadScene("Trainvasion");
    }

    public void CalculateEnemies()
    {
        if(isOnRed==true)
        {
            enemiesToSpawn = Random.Range(1,3);
        }
        else if(isOnYellow==true)
        {
            enemiesToSpawn = Random.Range(2, 4);
        }
    }

    public void Victory()
    {
        if(numPeople <= 10)
        {
            Debug.Log("Bad Ending");
        }
        else if(numPeople <= 25) 
        {
            Debug.Log("Okay Ending");
        }
        else if(numPeople <= 50)
        {
            Debug.Log("Good Ending");
        }
    }
}
