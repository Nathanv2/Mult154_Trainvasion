using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroStateMachine : MonoBehaviour
{
    private BattleStateMachine BSM;
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
    private Image ProgressBar;
    public GameObject Selector;
    //IEnumerator stuuf
    public GameObject EnemyToAttack;
    private bool actionStarted = false;
    private Vector3 startPosition;
    private float animSpeed = 10f;
    //Dead stuff
    private bool alive = true;
    //hero panel
    private HeroPanelStats stats;
    public GameObject HeroPanel;
    private Transform HeroPanelSpacer;

    private void Start()
    {
        //find spacer
        HeroPanelSpacer = GameObject.Find("BattleCanvas").transform.Find("HeroPanel").transform.Find("SpacerHeroPanel");
        //create panel and fill information of heroes
        CreateHeroPanel();
        

        startPosition = transform.position;
        cur_cooldown = Random.Range(0, hero.agility);
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
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
                BSM.HeroesToManage.Add(this.gameObject);
                currentState = TurnState.WAITING;
            break;

            case (TurnState.WAITING):

                break;           
            case (TurnState.ACTION):
                StartCoroutine(TimeForAction());
                break;

            case (TurnState.DEAD):
                if (!alive)
                {
                    return;
                }
                else
                {
                    //change tag
                    this.gameObject.tag = "DeadHero";
                    //not attackable
                    BSM.HerosInBattle.Remove(this.gameObject);
                    //not being able to manage hero
                    BSM.HeroesToManage.Remove(this.gameObject);
                    //deactivate selector
                    Selector.SetActive(false);
                    //reset GUI hero panel
                    BSM.ActionPanel.SetActive(false);
                    BSM.EnemySelectPanel.SetActive(false);
                    //remove item from performlist
                    if (BSM.HerosInBattle.Count > 0)
                    {
                        for (int i = 0; i < BSM.PerformList.Count; i++)
                        {
                            if (BSM.PerformList[i].AttackersGameObject == this.gameObject)
                            {
                                BSM.PerformList.Remove(BSM.PerformList[i]);
                            }
                            if (BSM.PerformList[i].attackersTarget == this.gameObject)
                            {
                                BSM.PerformList[i].attackersTarget = BSM.HerosInBattle[Random.Range(0, BSM.HerosInBattle.Count)];
                            }
                        }
                    }
                   

                    //change color or play death animation
                    this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(105, 105, 105, 255);
                    //reset hero input
                    BSM.battleStates = BattleStateMachine.PerformAction.CHECKALIVE;
                    alive = false;

                    alive = false;
                }

                break;
        }
    }

    void UpdateProgressBar()
    {
        cur_cooldown = cur_cooldown + Time.deltaTime * hero.dexterity;
        float calc_cooldown = cur_cooldown / max_cooldown;
        ProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
        if(cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.ADDTOLIST;
        }

    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        //animate The enemy near the hero to attack
        Vector3 EnemyPosition = new Vector3(EnemyToAttack.transform.position.x + 1.5f, EnemyToAttack.transform.position.y, EnemyToAttack.transform.position.z);
        while (MoveTowardsEnemy(EnemyPosition))
        {
            yield return null;
        }
        //wait a bit
        yield return new WaitForSeconds(0.5f);
        //do damage
        DoDamage();
        //animate back to start pos
        Vector3 firstPosition = startPosition;
        while (MoveTowardsStart(firstPosition))
        {
            yield return null;
        }

        //remove this performer from the list in BSM
        BSM.PerformList.RemoveAt(0);
        //reset BSM -> set to wait
        if (BSM.battleStates != BattleStateMachine.PerformAction.WIN && BSM.battleStates != BattleStateMachine.PerformAction.LOSE)
        {
            BSM.battleStates = BattleStateMachine.PerformAction.WAIT;
            //end coroutine
            actionStarted = false;
            //reset this enemy state
            cur_cooldown = 0f;
            currentState = TurnState.PROCESSING;
        }
        else
        {
            currentState = TurnState.WAITING;
        }
    }

    private bool MoveTowardsEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }
    private bool MoveTowardsStart(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    public void TakeDamage(float getDamageAmount)
    {
        hero.currentHealth -= getDamageAmount;
        if(hero.currentHealth <= 0)
        {
            hero.currentHealth = 0;
            currentState = TurnState.DEAD;
        }
        UpdateHeroPanel();
    }
    //do Damage
    void DoDamage()
    {
        float calc_damage = hero.currentAttack + BSM.PerformList[0].choosenAttack.attackDamage;
        EnemyToAttack.GetComponent<EnemyStateMachine>().TakeDamage(calc_damage);
    }


    //create hero panel
    void CreateHeroPanel()
    {
        HeroPanel = Instantiate(HeroPanel);
        stats = HeroPanel.GetComponent<HeroPanelStats>();
        stats.HeroName.text = hero.theName;
        stats.HeroHP.text = "HP: " + hero.currentHealth;//HP: 999
        stats.HeroMP.text = "MP: " + hero.currentMp;//MP: 999

        ProgressBar = stats.ProgressBar;
        HeroPanel.transform.SetParent(HeroPanelSpacer, false);
    }
    //Update stats of damage and or heal
    void UpdateHeroPanel()
    {
        stats.HeroHP.text = "HP: " + hero.currentHealth;
        stats.HeroMP.text = "MP: " + hero.currentMp;
    }
}
