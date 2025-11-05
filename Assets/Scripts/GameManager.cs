using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int counter = 0;
    private PlayerMove playerMove;
    private EnemyAI enemyAI;
    private UIManager uIManager;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        enemyAI = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>();
        uIManager = GameObject.FindWithTag("UiManager").GetComponent<UIManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
       
           

        if (counter == 0 && (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed || Keyboard.current.sKey.isPressed || Keyboard.current.wKey.isPressed) )
        {
            counter = 1;
            playerMove.MovePlayer();
            Debug.Log("Enemy Turn ");
            
            uIManager.whoTurn = "Enemy's Turn, Press space to end turn";
        }

        if (counter == 1 && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            counter = 0;
            enemyAI.TakeTurn();
            Debug.Log("Player Turn ");
            uIManager.whoTurn = "Player's Turn (W,A,S,D)";
        }

        if (uIManager.boolgameOver || uIManager.boolwinGame)
        {
            Time.timeScale = 0;
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
}
