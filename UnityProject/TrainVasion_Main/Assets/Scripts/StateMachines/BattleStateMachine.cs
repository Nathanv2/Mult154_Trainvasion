using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleStateMachine : MonoBehaviour
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,
        CHECKALIVE,
        WIN,
        LOSE,
    }
    public PerformAction battleStates;

    public List<HandleTurns> PerformList = new List<HandleTurns>();

    public List<GameObject> HerosInBattle = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>();

    public enum HeroGUI
    {
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }

    public HeroGUI HeroInput;

    public List<GameObject> HeroesToManage = new List<GameObject>();
    private HandleTurns HeroChoice;

    public GameObject EnemyButton;
    public Transform Spacer;

    public GameObject ActionPanel;
    public GameObject EnemySelectPanel;
    public GameObject SpecialsPanel;

    //SpecialAttacks
    public Transform actionSpacer;
    public Transform SpecialsSpacer;
    public GameObject actionButton;
    public GameObject specialsButton;
    private List<GameObject> atkBtns = new List<GameObject>();

    //enemy buttons
    private List<GameObject> enemyBtns = new List<GameObject>();

    //GameManager stuff
    public GameManager GM;

    [Header("Spawn Points")]
    public List<Transform> enemySpawnPoints = new List<Transform>();
    public List<Transform> heroSpawnPoints = new List<Transform>();
    public Transform mainHeroSpawnPoint;

    [Header("PrefabLists")]
    public List<GameObject> redZoneEnemies= new List<GameObject>();
    public List<GameObject> yellowZoneEnemies = new List<GameObject>();
    public List<GameObject> BlueZoneEnemies = new List<GameObject>();

    public List<GameObject> heroesToBeUsed= new List<GameObject>();
    public GameObject enemyPrefab;
    public GameObject heroPrefab;

    [Header("GUI stuff")]
    //EnemyGUI
    public GameObject enemyStatsPanel;
    public GameObject infoButton;
    public GameObject infoCloseButton;
    public GameObject endOfBattleScreen;

    public void Awake()
    {
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Instantiate(heroPrefab, mainHeroSpawnPoint.position, Quaternion.identity);

        for (int i = 0; i < GM.NumberOfHeroes; i++)
        {
            GameObject NewHero = Instantiate(GM.ListOfHeroes[i], heroSpawnPoints[i].position, Quaternion.identity) as GameObject;
            NewHero.name = NewHero.GetComponent<HeroStateMachine>().hero.theName + "_" + (i + 1);
            NewHero.GetComponent<HeroStateMachine>().hero.theName = NewHero.name;
            //HerosInBattle.Add(NewHero);
        }

        if (GM.isOnRed)
        {
            for (int i = 0; i < GM.enemiesToSpawn; i++)
            {
                GameObject NewEnemy = Instantiate(GM.RedStopEnemies[0].gameObject, enemySpawnPoints[i].position, Quaternion.identity) as GameObject;
                NewEnemy.name = NewEnemy.GetComponent<EnemyStateMachine>().enemy.theName + "_" + (i + 1);
                NewEnemy.GetComponent<EnemyStateMachine>().enemy.theName = NewEnemy.name;
                EnemiesInBattle.Add(NewEnemy);
            }
        }
        else if (GM.isOnYellow)
        {
            for (int i = 0; i < GM.enemiesToSpawn; i++)
            {
                GameObject NewEnemy = Instantiate(GM.YellowStopEnemies[Random.Range(0,2)].gameObject, enemySpawnPoints[i].position, Quaternion.identity) as GameObject;
                NewEnemy.name = NewEnemy.GetComponent<EnemyStateMachine>().enemy.theName + "_" + (i + 1);
                NewEnemy.GetComponent<EnemyStateMachine>().enemy.theName = NewEnemy.name;
                EnemiesInBattle.Add(NewEnemy);
            }
        }
        else if (GM.isOnBlue)
        {
            for (int i = 0; i < GM.enemiesToSpawn; i++)
            {
                GameObject NewEnemy = Instantiate(GM.BlueStopEnemies[Random.Range(0, 3)].gameObject, enemySpawnPoints[i].position, Quaternion.identity) as GameObject;
                NewEnemy.name = NewEnemy.GetComponent<EnemyStateMachine>().enemy.theName + "_" + (i + 1);
                NewEnemy.GetComponent<EnemyStateMachine>().enemy.theName = NewEnemy.name;
                EnemiesInBattle.Add(NewEnemy);
            }
        }


    }

    private void Start()
    {
        //GM = GameObject.Find("Game Manager").GetComponent<GameManager>();

        battleStates = PerformAction.WAIT;
        //EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));
        HeroInput = HeroGUI.ACTIVATE;

        ActionPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);
        SpecialsPanel.SetActive(false);

        EnemyButtons();
    }
    private void Update()
    {
        switch (battleStates)
        {
            case (PerformAction.WAIT):
                if (PerformList.Count > 0)
                {
                    battleStates = PerformAction.TAKEACTION;
                }
                break;
            case (PerformAction.TAKEACTION):
                GameObject performer = GameObject.Find(PerformList[0].Attacker);
                if (PerformList[0].Type == "Enemy")
                {
                    EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                    for (int i = 0; i < HerosInBattle.Count; i++)
                    {
                        if (PerformList[0].attackersTarget == HerosInBattle[i])
                        {
                            ESM.HeroToAttack = PerformList[0].attackersTarget;
                            ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                            break;
                        }
                        else
                        {
                            PerformList[0].attackersTarget = HerosInBattle[Random.Range(0, HerosInBattle.Count)];
                            ESM.HeroToAttack = PerformList[0].attackersTarget;
                            ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                        }
                    }
                }

                if (PerformList[0].Type == "Hero")
                {
                    HeroStateMachine HSM = performer.GetComponent<HeroStateMachine>();
                    HSM.EnemyToAttack = PerformList[0].attackersTarget;
                    HSM.currentState = HeroStateMachine.TurnState.ACTION;
                }
                battleStates = PerformAction.PERFORMACTION;
                break;
            case (PerformAction.PERFORMACTION):
                //Idle
                break;

            case (PerformAction.CHECKALIVE):
                if (HerosInBattle.Count < 1)
                {
                    battleStates = PerformAction.LOSE;
                    //Lose battle
                }
                else if (EnemiesInBattle.Count < 1)
                {
                    battleStates = PerformAction.WIN;
                    //win battle
                }
                else
                {
                    //call function
                    clearAttackPanel();
                    HeroInput = HeroGUI.ACTIVATE;
                }
                break;

            case (PerformAction.WIN):
                {
                    Debug.Log("You won the battle");
                    for (int i = 0; i < HerosInBattle.Count; i++)
                    {
                        HerosInBattle[i].GetComponent<HeroStateMachine>().currentState = HeroStateMachine.TurnState.WAITING;
                    }
                    endOfBattleScreen.SetActive(true);
                    TextMeshProUGUI BattleResults = GameObject.Find("BattleStatusText").GetComponent<TextMeshProUGUI>();
                    BattleResults.text = "You won the battle!!!";

                }
                break;

            case (PerformAction.LOSE):
                {
                    Debug.Log("You lost the battle");
                    endOfBattleScreen.SetActive(true);
                    TextMeshProUGUI BattleResults = GameObject.Find("BattleStatusText").GetComponent<TextMeshProUGUI>();
                    BattleResults.text = "You lost the battle...And your people...we'll take your dignity too.";
                    GM.numPeople = GM.numPeople - 1;
                    GM.ResetPeopleNum();
                }
                break;
        }

        switch (HeroInput)
        {
            case (HeroGUI.ACTIVATE):
                if (HeroesToManage.Count > 0)
                {
                    HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(true);
                    HeroChoice = new HandleTurns();

                    ActionPanel.SetActive(true);
                    //populate action buttons
                    CreateAttackButtons();

                    HeroInput = HeroGUI.WAITING;
                }
                break;

            case (HeroGUI.WAITING):

                break;
            case (HeroGUI.DONE):
                HeroInputDone();
                break;
        }
    }

    public void CollectActions(HandleTurns input)
    {
        PerformList.Add(input);
    }


    public void EnemyButtons()
    {
        //cleanup
        foreach (GameObject enemyBtn in enemyBtns)
        {
            Destroy(enemyBtn);
        }
        enemyBtns.Clear();
        //create buttons
        foreach (GameObject enemy in EnemiesInBattle)
        {
            GameObject newButton = Instantiate(EnemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton>();

            EnemyStateMachine cur_enemy = enemy.GetComponent<EnemyStateMachine>();
            //use new textmeshpro system instead of old (find child) it doesnt work anymore also use GetCompInChildren
            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = cur_enemy.enemy.theName;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent(Spacer, false);
            enemyBtns.Add(newButton);
        }
    }

    public void Input1()//attackbutton
    {
        HeroChoice.Attacker = HeroesToManage[0].name;
        HeroChoice.AttackersGameObject = HeroesToManage[0];
        HeroChoice.Type = "Hero";
        HeroChoice.choosenAttack = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.attacks[0];
        ActionPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }

    public void Input2(GameObject choosenEnemy)//enemySelection
    {
        HeroChoice.attackersTarget = choosenEnemy;
        HeroInput = HeroGUI.DONE;
    }

    public void HeroInputDone()
    {
        PerformList.Add(HeroChoice);
        //clear attack pane;
        clearAttackPanel();

        HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(false);
        HeroesToManage.RemoveAt(0);
        HeroInput = HeroGUI.ACTIVATE;
    }

    void clearAttackPanel()
    {
        EnemySelectPanel.SetActive(false);
        ActionPanel.SetActive(false);
        SpecialsPanel.SetActive(false);
        foreach (GameObject atkBtn in atkBtns)
        {
            Destroy(atkBtn);
        }
        atkBtns.Clear();
    }


    //create action button
    void CreateAttackButtons()
    {
        GameObject AttackButton = Instantiate(actionButton);
        TextMeshProUGUI AttackButtonText = AttackButton.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        AttackButtonText.text = "Attack";
        AttackButton.GetComponent<Button>().onClick.AddListener(() => Input1());
        AttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(AttackButton);

        GameObject SpecialAttackButton = Instantiate(actionButton);
        TextMeshProUGUI SpecialAttackButtonText = SpecialAttackButton.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        SpecialAttackButtonText.text = "Specials";
        SpecialAttackButton.GetComponent<Button>().onClick.AddListener(() => Input3());
        //Later
        SpecialAttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(SpecialAttackButton);

        if (HeroesToManage[0].GetComponent<HeroStateMachine>().hero.SpecialAttacks.Count > 0 && HeroesToManage[0].GetComponent<HeroStateMachine>().hero.currentMp >= HeroesToManage[0].GetComponent<HeroStateMachine>().hero.baseMp)
        {
            foreach (BaseAttack specialAtk in HeroesToManage[0].GetComponent<HeroStateMachine>().hero.SpecialAttacks)
            {
                GameObject SpecialsButton = Instantiate(specialsButton);
                TextMeshProUGUI SpecialsButtonText = specialsButton.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
                SpecialsButtonText.text = specialAtk.attackName;
                AttackButton ATB = specialsButton.GetComponent<AttackButton>();
                ATB.specialAttackToPerform = specialAtk;
                SpecialsButton.transform.SetParent(SpecialsSpacer, false);
                atkBtns.Add(SpecialsButton);
            }
        }
        else
        {
            SpecialAttackButton.GetComponent<Button>().interactable = false;
        }
    }

    public void Input4(BaseAttack chooseSpecial)//choose Special Attack
    {
        HeroChoice.Attacker = HeroesToManage[0].name;
        HeroChoice.AttackersGameObject = HeroesToManage[0];
        HeroChoice.Type = "Hero";

        HeroChoice.choosenAttack = chooseSpecial;
        SpecialsPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
        HeroesToManage[0].GetComponent<HeroStateMachine>().hero.currentMp -= chooseSpecial.attackCost;
    }

    public void Input3()//switching to speacials
    {
        ActionPanel.SetActive(false);
        SpecialsPanel.SetActive(true);
    }

    public void SeeEnemyStats()
    {
        enemyStatsPanel.SetActive(true);
        infoButton.SetActive(false);
        infoCloseButton.SetActive(true);
    }
    public void CloseEnemyStats()
    {
        enemyStatsPanel.SetActive(false);
        infoCloseButton.SetActive(false);
        infoButton.SetActive(true);
    }

    public void ReturnToMainScene()
    {
        SceneManager.UnloadSceneAsync("Combat");
        GM.isOnMainGame = true;
        GM.EnableObjects();
    }

}
