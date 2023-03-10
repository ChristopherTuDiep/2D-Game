using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, ESCAPED, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    //Prefabs used for the Battle System
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject characterHUDPrefab;
    public GameObject enemySelectionArrow;

    //Changing dialogue text at bottom
    public Camera mainCamera;
    public GameObject mainCanvas;
    public TMP_Text dialogue;


    private Player[] characterOrder; //Order of characters from top to bottom
    private Enemy[] enemyOrder; //Order of enemies from top to bottom

    //Keeps track of turns and initiative
    public BattleState state;
    private List<Entity> turnOrder;
    private int turnIncrement;

    //Menu if you win
    [SerializeField] GameObject victoryScreen;

    //Static spacing for the battle screen
    private readonly float entityY = 2.75f;
    private readonly float entityYSpacing = 2f;

    private readonly float enemyEntityX = -2f;
    private readonly float entityXSpacing = 2f;

    private readonly float playerEntityY = 3.6f;
    private readonly float playerEntityX = 2.75f;
    private readonly float playerXSpacing = 1f;
    private readonly float playerTurnPosition = 2f;

    private readonly float hudX = -175f;
    private readonly float hudY = -120f;
    private readonly float hudSpacing = 160f;

    private readonly float arrowYSpacing = 1.2f;

    void Start()
    {
        victoryScreen.SetActive(false);
        state = BattleState.START;
        turnIncrement = 0;
        turnOrder = new List<Entity>();
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        List<Entity> entities = new List<Entity>();
        var random = new System.Random();
        Vector2 hudPos;

        enemySelectionArrow = Instantiate(enemySelectionArrow);
        enemySelectionArrow.SetActive(false);

        //Instantiates characters, their huds, and the order
        int numberOfCharacters = GameBrain.Instance.PlayerCount();
        characterOrder = new Player[numberOfCharacters];

        for (int i = 0; i < numberOfCharacters; i++)
        {
            GameObject playerGO = Instantiate(playerPrefab);

            playerGO.transform.position = EntityPosition(playerGO, i);

            Player playerEntity = playerGO.GetComponent<Player>();

            GameBrain.Instance.SetStats(playerEntity, i);

            playerEntity.InCombat();
            characterOrder[i] = playerEntity;

            hudPos = Vector2.zero;
            hudPos.y = hudY - (hudSpacing * i);
            hudPos.x = hudX;

            //Setting up the character HUD
            GameObject characterHUDGO = Instantiate(characterHUDPrefab, hudPos, Quaternion.identity);
            characterHUDGO.transform.SetParent(mainCanvas.transform, false);


            CharacterHUD characterHUD = characterHUDGO.GetComponent<CharacterHUD>();

            playerEntity.SetHUD(characterHUD);

            playerEntity.UpdateHUD();

            entities.Add(playerEntity);
        }

        //Instantiates enemy and order
        //int enemyNumber = random.Next(1, 4);
        int enemyNumber = 1;
        enemyOrder = new Enemy[enemyNumber];
        for (int i = 0; i < enemyNumber; i++)
        {
            GameObject enemyGO = Instantiate(enemyPrefab);

            enemyGO.transform.position = EntityPosition(enemyGO, i);
            
            enemyOrder[i] = enemyGO.GetComponent<Enemy>();
            Entity enemyEntity = enemyGO.GetComponent<Entity>();
            enemyEntity.UpdateHUD();

            entities.Add(enemyEntity);
        }

        dialogue.text = "Enemies appears...";

        //If not enough enemies/players
        if (characterOrder.Length < 1)
        {
            Debug.Log("Not enough Players for battle.");
        }
        if (enemyOrder.Length < 1)
        {
            Debug.Log("Not enough Enemies for battle.");
        }

        yield return new WaitForSeconds(2f);

        //Order turn order by each entities' speed
        turnOrder = entities.OrderBy(f => f.Speed()).ToList<Entity>();
        turnOrder.Reverse();

        TurnOrder();
    }

    //Runs through turn order
    void TurnOrder()
    {
        //If we reach the end of the turn orde rand battle is still going, reset increment to top of turn order
        if (turnIncrement >= turnOrder.Count)
        {
            turnIncrement = 0;
        }

        //Skip any entities that might be dead
        while (turnOrder[turnIncrement].IsDead())
        {
            turnIncrement++;
            if (turnIncrement >= turnOrder.Count)
            {
                turnIncrement = 0;
            }
        }

        Entity currentEntity;

        if (state == BattleState.WON || state == BattleState.LOST || state == BattleState.ESCAPED) //If a end-game status, ends battle
        {
            EndBattle();
        }
        else if (turnOrder[turnIncrement].IsPlayerEntity) //If the entity is a player entity
        { 
            currentEntity= turnOrder[turnIncrement];
            turnIncrement++;
            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn(currentEntity));
        }
        else //If the entity is an enemy
        {
            currentEntity = turnOrder[turnIncrement];
            turnIncrement++;
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn(currentEntity));
        }
    }

    //Method that controls the player's turn
    IEnumerator PlayerTurn(Entity character)
    {
        character.IsCurrentTurn = true;

        //Keeps track of current enemy player wishes to attack
        int currentTarget = 0;

        while (enemyOrder[currentTarget].IsDead())
        {
            currentTarget++;
            if(currentTarget > enemyOrder.Length - 1)
            {
                Debug.Log("Well something went wrong");
            }
        }

        BattleHandler.SetState(character, enemyOrder[currentTarget]);

        MoveArrow(currentTarget);

        enemySelectionArrow.SetActive(true);
        dialogue.text = "Player's Turn.";

        while(!BattleHandler.IsButtonPressed())
        {
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                
                do
                {
                    currentTarget--;
                    if (currentTarget < 0)
                    {
                        currentTarget = enemyOrder.Length - 1;
                    }
                } while (enemyOrder[currentTarget].IsDead());

                MoveArrow(currentTarget);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                do
                {
                    currentTarget++;
                    if (currentTarget >= enemyOrder.Length)
                    {
                        currentTarget = 0;
                    }
                } while (enemyOrder[currentTarget].IsDead());

                MoveArrow(currentTarget);
            }

            BattleHandler.SetState(character, enemyOrder[currentTarget]);

            yield return null;
        }

        if(BattleHandler.TriedToEscape())
        {
            if (BattleHandler.HasEscaped())
            {
                state = BattleState.ESCAPED;
            }
        }

        dialogue.text = BattleHandler.GetDialogue();

        character.UpdateHUD();

        enemySelectionArrow.SetActive(false);

        enemyOrder[currentTarget].UpdateHUD();

        if (BattleHandler.IsTargetDead())
        {
            if (IsAllDead(enemyOrder))
            {
                state = BattleState.WON;
            }
        }

        character.IsCurrentTurn = false;

        yield return new WaitForSeconds(2f);

        TurnOrder();
    }

    //Method for controlling the Enemy's turn
    IEnumerator EnemyTurn(Entity enemy)
    {
        enemy.IsCurrentTurn = true;

        var random = new System.Random();
        int randomPlayer = random.Next(0, characterOrder.Length - 1);

        while (characterOrder[randomPlayer].IsDead())
        {
            randomPlayer++;
            if (randomPlayer >= characterOrder.Length)
            {
                randomPlayer = 0;
            }
        }

        Entity victim = characterOrder[randomPlayer];
        BattleHandler.SetState(enemy, victim);
        bool isDead = false;

        dialogue.text = "Enemy attacks!";

        yield return new WaitForSeconds(1f);

        if(BattleHandler.Hit())
        {
            BattleHandler.WeaponAttack();

            isDead = BattleHandler.IsTargetDead();

            characterOrder[randomPlayer].UpdateHUD();

            dialogue.text = "Enemy hits!";
        }
        else
        {
            dialogue.text = "Enemy misses!";
        }

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            if(IsAllDead(characterOrder))
            {
                state = BattleState.LOST;
            }
        }

        enemy.IsCurrentTurn = false;

        TurnOrder();
    }

    //Method that controls conditions for if the battle ends
    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            StartCoroutine(Victory());
        }
        else if(state == BattleState.LOST)
        {
            dialogue.text = "You have been defeated...";
        }
        else
        {
            dialogue.text = "You have escaped!";
        }

        GameBrain.Instance.locationsToAdd.Clear();

        GameBrain.Instance.UpdateStats(characterOrder);

        SceneManager.LoadScene("World_Scene");
    }

    IEnumerator Victory()
    {
        victoryScreen.SetActive(true);
        dialogue.text = "You won the battle!";

        int totalExp = 0;

        for (int i = 0; i < enemyOrder.Length; i++)
        {
            totalExp += enemyOrder[i].ExpWorth();
        }

        for (int i = 0; i < characterOrder.Length; i++)
        {
            characterOrder[i].GainExp(Mathf.RoundToInt(totalExp / GameBrain.Instance.PlayerCount())); ;
            characterOrder[i].UpdateHUD();
        }
        GameBrain.Instance.AddLocations();

        yield return new WaitForSeconds(3f);
    }

    //Method that checks if all the entities on one side are dead
    bool IsAllDead(Entity[] entities)
    {
        for(int i = 0; i < entities.Length; i++)
        {
            if (!entities[i].IsDead())
            {
                return false;
            }
        }
        return true;
    }

    //Sets the positions for the entities on the field
    Vector2 EntityPosition(GameObject currentEntity, int currentIncrement)
    {
        Vector2 pos = Vector2.zero;
        pos.y = entityY - (entityYSpacing * currentIncrement);
        if(currentEntity.GetComponent<Entity>().IsPlayerEntity)
        {
            pos.x = playerEntityX + (playerXSpacing * currentIncrement);
        }
        else
        {
            pos.x = enemyEntityX;
            if (currentIncrement % 2 != 0)
            {
                pos.x -= entityXSpacing;
            }
        }
       
        return pos;
    }

    //Helper method that moves the arrow above the target's head
    public void MoveArrow(int targetLocation)
    {
        Vector2 arrowPos = enemyOrder[targetLocation].transform.position;
        arrowPos.y += arrowYSpacing;

        enemySelectionArrow.transform.position = arrowPos;
    }
}
