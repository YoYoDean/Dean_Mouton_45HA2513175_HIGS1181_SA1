using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //declaring variables

    private const int V = 1;
    int counter = 0;
    private PlayerMove playerMove;
    private EnemyAI enemyAI;
    private UIManager uIManager;
   // private bool endTurn = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        enemyAI = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>();              //getting access to scripts
        uIManager = GameObject.FindWithTag("UiManager").GetComponent<UIManager>();
        Time.timeScale = V; // setting time to run

        
    }

    // Update is called once per frame
    void Update()
    {


            // checking which key is pressed and if its players turn
        if (counter == 0 && (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame))
        {
            //endTurn = false;        //turn done
            counter = 1;            //counter to help keep track of turn
            playerMove.MovePlayer();        //calling moveplayer method that moves player
            Debug.Log("Enemy Turn ");
            StartCoroutine(TurnDelay(.5f));         //turn delay
            uIManager.whoTurn = "Enemy's Turn, Press space to end turn"; //display its now enemy's turn
        }

        if (counter == 1 && Keyboard.current.spaceKey.wasPressedThisFrame) //checking if its enemy turn and if player done
        {
            //endTurn = false;
            counter = 0;
            enemyAI.TakeTurn(); // caling enemy move method      ,,,,,,, Rest same as above
            Debug.Log("Player Turn ");
            uIManager.whoTurn = "Player's Turn (W,A,S,D)";
            StartCoroutine(TurnDelay(.5f));
        }

        if (uIManager.boolgameOver || uIManager.boolwinGame)        //checking win or lose conditions
        {
            Time.timeScale = V;
            if (Keyboard.current.rKey.isPressed)
            {
                SceneManager.LoadScene("SampleScene");// reload scene if R is pressed
            }
        }

        if (Keyboard.current.rKey.isPressed)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
    IEnumerator TurnDelay(float delay)
    {
        yield return new WaitForSeconds(delay); //waiting after turns
       // endTurn = true;

    }
}
