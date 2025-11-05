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
    private const int V = 1;
    int counter = 0;
    private PlayerMove playerMove;
    private EnemyAI enemyAI;
    private UIManager uIManager;
    private bool endTurn = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        enemyAI = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>();
        uIManager = GameObject.FindWithTag("UiManager").GetComponent<UIManager>();
        Time.timeScale = V;

        
    }

    // Update is called once per frame
    void Update()
    {



        if (counter == 0 && (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame))
        {
            endTurn = false;
            counter = 1;
            playerMove.MovePlayer();
            Debug.Log("Enemy Turn ");
            StartCoroutine(TurnDelay(.5f));
            uIManager.whoTurn = "Enemy's Turn, Press space to end turn";
        }

        if (counter == 1 && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            endTurn = false;
            counter = 0;
            enemyAI.TakeTurn();
            Debug.Log("Player Turn ");
            uIManager.whoTurn = "Player's Turn (W,A,S,D)";
            StartCoroutine(TurnDelay(.5f));
        }

        if (uIManager.boolgameOver || uIManager.boolwinGame)
        {
            Time.timeScale = V;
            if (Keyboard.current.rKey.isPressed)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (Keyboard.current.rKey.isPressed)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
    IEnumerator TurnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        endTurn = true;

    }
}
