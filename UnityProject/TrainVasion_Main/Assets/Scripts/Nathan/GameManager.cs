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
    public GameObject backgroundBar;
    public GameObject energyBarUI;
    public GameObject controlPanel;
    public GameObject nathanCanvas;
    public GameObject mainCamera;

    public int NumberOfHeroes;

    public bool isOnMainGame;

    //ZoneColliderStuff

    public bool isOnRed;
    public bool isOnYellow;
    public bool isOnBlue;

    //BloackadeStuff
    public bool blockadeAhead;
    public GameObject blockadePrefab;
    public List<GameObject> blockades = new List<GameObject>();

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
        blockadeAhead= false;
        isOnMainGame= true;
        numPeople = 0;
        //FindStuff();
        
    }

    private void Update()
    {
        GameOver();
        CalculateEnemies();
        HeroesToSpawn(numPeople);
        BlockadeTrigger(blockadeAhead);

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
        else if(nathanCanvas == null)
        {
            nathanCanvas = GameObject.Find("Canvas (Nathan)");
        }
        else if(mainCamera == null)
        {
            mainCamera = GameObject.Find("Main Camera");
        }
        else if(backgroundBar == null)
        {
            backgroundBar = GameObject.Find("BackgroundBar");
        }
        else if(energyBar == null)
        {
            //energyBar = GameObject.FindWithTag("EnergyBar");
        }
        else if(controlPanel == null)
        {
            controlPanel = GameObject.Find("ControlPanel");
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

    public void EnableObjects()
    {
        backgroundBar.gameObject.SetActive(true);
        energyBarUI.gameObject.SetActive(true);
        controlPanel.gameObject.SetActive(true);
        nathanCanvas.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(true);
    }

    public void DisableObjects()
    {
        backgroundBar.gameObject.SetActive(false);
        energyBarUI.gameObject.SetActive(false);
        controlPanel.gameObject.SetActive(false);
        nathanCanvas.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(false);
    }

    //Combat scene functions
    public void CalculateEnemies()
    {
        if (isOnRed == true)
        {
            enemiesToSpawn = Random.Range(1, 3);
        }
        else if (isOnYellow == true)
        {
            enemiesToSpawn = Random.Range(2, 4);
        }
        else if (isOnBlue == true)
        {
            enemiesToSpawn = 4;
        }
    }

    public void HeroesToSpawn(int PeopleHelping)
    {
        if(PeopleHelping <= 5)
        {
           NumberOfHeroes= 1;
            //Debug.Log("You will spawn 1 hero");
        }
        else if(PeopleHelping > 5 && PeopleHelping <= 15)
        {
            NumberOfHeroes= 2;
            Debug.Log("You will spawn 2 heroes");
        }
        else if (PeopleHelping > 15 && PeopleHelping <= 30)
        {
            NumberOfHeroes = 3;
            Debug.Log("You will spawn 3 heroes");
        }
        else if (PeopleHelping >30)
        {
            NumberOfHeroes = 4;
            Debug.Log("You will spawn 4 heroes");
        }
    }

    public void BlockadeTrigger(bool BlockadeAhead)
    {
        if(BlockadeAhead == true)
        {
            Debug.Log("Theres a blockade");
            
        }
        else if(BlockadeAhead == false) 
        {
            blockadeAhead= false;
        }
    }
    public void DestroyBlockade()
    {
        Destroy(blockades[0].gameObject);
        blockades.Clear();
        uiManager.blockadeMenu.SetActive(false);
        uiManager.blockadeFail.SetActive(false);
        uiManager.blockadeButton.SetActive(false);
        blockadeAhead= false;
    }
}
