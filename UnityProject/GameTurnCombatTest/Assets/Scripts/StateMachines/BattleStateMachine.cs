using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleStateMachine : MonoBehaviour
{
  public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,
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
    private List<GameObject> atkBtns = new List<GameObject>();


    private void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
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
                if(PerformList.Count > 0)
                {
                    battleStates = PerformAction.TAKEACTION;
                }
            break;
            case (PerformAction.TAKEACTION):
                GameObject performer = GameObject.Find(PerformList[0].Attacker);
                if (PerformList[0].Type == "Enemy")
                {
                    EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                    for(int i = 0; i<HerosInBattle.Count; i++)
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

    
    void EnemyButtons()
    {
        foreach(GameObject enemy in EnemiesInBattle)
        {
            GameObject newButton = Instantiate (EnemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton>();

            EnemyStateMachine cur_enemy = enemy.GetComponent<EnemyStateMachine>();
            //use new textmeshpro system instead of old (find child) it doesnt work anymore also use GetCompInChildren
            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = cur_enemy.enemy.theName;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent(Spacer, false);
        }
    }

    public void Input1()//attackbutton
    {
        HeroChoice.Attacker = HeroesToManage[0].name;
        HeroChoice.AttackersGameObject = HeroesToManage[0];
        HeroChoice.Type = "Hero";

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
        EnemySelectPanel.SetActive(false);

        //clean attack panel
        foreach(GameObject atkBtn in atkBtns)
        {
            Destroy(atkBtn);
        }
        atkBtns.Clear();

        HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(false);
        HeroesToManage.RemoveAt(0);
        HeroInput = HeroGUI.ACTIVATE;
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
        //Later
        SpecialAttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(SpecialAttackButton);
    }
}
