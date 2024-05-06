using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateMachine : MonoBehaviour
{

    private BattleStateMachine BSM;
    public EnemyScript enemy;

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD
    }

    public TurnState currentState;
    //for progress bar
    private float cur_cooldown = 0f;
    private float max_cooldown = 10f;
    //this game object
    private Vector3 startPosition;
    public GameObject Selector;
    //IEnumerator stuff
    private bool actionStarted = false;
    public GameObject HeroToAttack;
    private float animSpeed = 10f;

    //alive
    private bool alive = true;
    public ParticleSystem takeDamageFX;

    //PanelStuff
    private EnemyPanelStats stats;
    public GameObject EnemyStatsPanel;
    private Transform EnemyStatsPanelSpacer;
    private Image ProgressBar;

    public AudioSource audioSource;

    private void Start()
    {
        takeDamageFX.Stop();
        //find spacer
        EnemyStatsPanelSpacer = GameObject.Find("BattleCanvas").transform.Find("EnemyStatsPanel").transform.Find("SpacerEnemyStatsPanel");
        //create panel and fill information of heroes
        CreateEnemyPanel();


        currentState = TurnState.PROCESSING;
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        startPosition = transform.position;
    }

    private void Update()
    {
        switch (currentState)
        {
            case (TurnState.PROCESSING):
                UpdateProgressBar();
                break;
            case (TurnState.CHOOSEACTION):
                ChooseAction();
                currentState = TurnState.WAITING;
                break;
            case (TurnState.WAITING):
                //idle state
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
                    //change tag of enemy
                    this.gameObject.tag = "DeadEnemy";
                    //remove from BSM 
                    BSM.EnemiesInBattle.Remove(this.gameObject);
                    //disable Selector
                    Selector.SetActive(false);
                    //remove attacks
                    if (BSM.EnemiesInBattle.Count > 0)
                    {
                        for (int i = 0; i < BSM.PerformList.Count; i++)
                        {
                            if (BSM.PerformList[i].AttackersGameObject == this.gameObject)
                            {
                                BSM.PerformList.Remove(BSM.PerformList[i]);
                            }
                            if (BSM.PerformList[i].attackersTarget == this.gameObject)
                            {
                                BSM.PerformList[i].attackersTarget = BSM.EnemiesInBattle[Random.Range(0, BSM.EnemiesInBattle.Count)];
                            }
                        }
                    }
                    //change color of dead enemy / play anims
                    this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(105, 105, 105, 255);
                    this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = new Color32(105, 105, 105, 255);
                    this.gameObject.GetComponentInChildren<Animator>().enabled= false;
                    //set alive to be false
                    alive = false;
                    //reset enemy buttons
                    BSM.EnemyButtons();
                    //check alive
                    BSM.battleStates = BattleStateMachine.PerformAction.CHECKALIVE;

                }
                break;
        }
    }

    void UpdateProgressBar()
    {
        cur_cooldown = cur_cooldown + Time.deltaTime * enemy.dexterity / 1.0f;
        float calc_cooldown = cur_cooldown / max_cooldown;
        ProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
        if (cur_cooldown >= max_cooldown)
        {
            currentState = TurnState.CHOOSEACTION;
        }

    }
    void ChooseAction()
    {
        HandleTurns myAttack = new HandleTurns();
        myAttack.Attacker = enemy.theName;
        myAttack.Type = "Enemy";
        myAttack.AttackersGameObject = this.gameObject;
        myAttack.attackersTarget = BSM.HerosInBattle[Random.Range(0, BSM.HerosInBattle.Count)];

        int num = Random.Range(0, enemy.attacks.Count);
        myAttack.choosenAttack = enemy.attacks[num];
        Debug.Log(this.gameObject.name + " has choosen " + myAttack.choosenAttack + " and do " + myAttack.choosenAttack.attackDamage + " damage ");

        BSM.CollectActions(myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        //animate The enemy near the hero to attack
        Vector3 heroPosition = new Vector3(HeroToAttack.transform.position.x-1.5f,HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        while (MoveTowardsEnemy(heroPosition))
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
        BSM.battleStates = BattleStateMachine.PerformAction.WAIT;
        //end coroutine
        actionStarted = false;
        //reset this enemy state
        cur_cooldown = 0f;
        currentState = TurnState.PROCESSING;
    }

    private bool MoveTowardsEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }
    private bool MoveTowardsStart(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    void DoDamage()
    {
        float calc_damage = enemy.currentAttack + BSM.PerformList[0].choosenAttack.attackDamage;
        HeroToAttack.GetComponent<HeroStateMachine> ().TakeDamage(calc_damage);
        audioSource.Play(); 
    }

    public void TakeDamage(float getDamageAmount)
    {
        enemy.currentHealth -= getDamageAmount;
        if(enemy.currentHealth <= 0f)
        {
            enemy.currentHealth = 0f;
            currentState = TurnState.DEAD;
        }
        takeDamageFX.Play();
        UpdateEnemyPanel();
        
    }

    //Panel Work

    void CreateEnemyPanel()
    {
        EnemyStatsPanel = Instantiate(EnemyStatsPanel);
        stats = EnemyStatsPanel.GetComponent<EnemyPanelStats>();
        stats.EnemyName.text = enemy.theName;
        stats.EnemyHP.text = "HP: " + enemy.currentHealth;//HP: 999
        stats.EnemyMP.text = "MP: " + enemy.currentMp;//MP: 999

        ProgressBar = stats.ProgressBar;
        EnemyStatsPanel.transform.SetParent(EnemyStatsPanelSpacer, false);
    }
    //Update stats of damage and or heal
    void UpdateEnemyPanel()
    {
        stats.EnemyHP.text = "HP: " + enemy.currentHealth;
        stats.EnemyMP.text = "MP: " + enemy.currentMp;
    }
}
