using System.Runtime.CompilerServices;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    int counter = 0;
    private PlayerMove playerMove;
    private EnemyAI enemyAI;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        enemyAI = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
           

        if (counter == 0 && (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed || Keyboard.current.sKey.isPressed || Keyboard.current.wKey.isPressed) )
        {
            counter = 1;
            playerMove.MovePlayer();   
            Debug.Log("Enemy Turn ");
        }

        if (counter == 1 && Keyboard.current.spaceKey.isPressed)
        {
            counter = 0;
            enemyAI.TakeTurn();
            Debug.Log("Player Turn "); 
        } 
            
                   
        
        
    }
}
