using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    //declarinf variables
    [Header("Movement Settings")]
    [Tooltip("Time (in seconds) it takes to move one tile.")]
    public float moveTime = 0.2f;

    
    public Tilemap obstacleTilemap;

    private Rigidbody2D rb2D;
    private float inverseMoveTime;
    private Vector3 targetPosition;
    public bool gameOver;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        UIManager uIManager = GameObject.FindWithTag("UiManager").GetComponent<UIManager>();        //getting components
    }

    private void Start()
    {
        inverseMoveTime = 1f / moveTime;
        targetPosition = rb2D.position; // setting target position
    }

    public void TakeTurn()
    {
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;        //finding player position
        targetPosition = playerPos - rb2D.transform.position;           //setting target position
        Debug.Log(targetPosition);

        Vector3 moveDir = Vector3.zero;         //initializing

        if (Math.Abs(targetPosition.x) > Math.Abs(targetPosition.y))        //checking shortest route
        {
            moveDir = targetPosition.x > 0 ? Vector3.right : Vector3.left;      //moving on x axis
        }
        else
        {
            moveDir = targetPosition.y > 0 ? Vector3.up : Vector3.down; //moving on y axis
        }

        


        if (moveDir != Vector3.zero)   //checking if movedirection has a value
        {
            Vector3 nextPos = rb2D.transform.position + moveDir;  //setting new position to move to
            
            Debug.Log("nextpos: "  + nextPos);
            if (CanMoveTo(nextPos))     // Check obstacle before moving
            {
                rb2D.MovePosition(nextPos);     //moves enemy
                Debug.Log("Enemy moved.");
            }
            else
            {
                Debug.Log("Enemy blocked!");

                if (Math.Abs(targetPosition.x) > Math.Abs(targetPosition.y))        //if blocked find new shortest route
                {
                    moveDir = targetPosition.y > 0 ? Vector3.up : Vector3.down;
                    nextPos = rb2D.transform.position + moveDir;                
                    rb2D.MovePosition(nextPos);
                    Debug.Log("Enemy moved.");
                }
                else                                                            //basically go left or right instead of up or down
                {
                    moveDir = targetPosition.x > 0 ? Vector3.right : Vector3.left;
                    nextPos = rb2D.transform.position + moveDir;
                    rb2D.MovePosition(nextPos);
                    Debug.Log("Enemy moved.");
                }
                
            }
        }
    }

    private bool CanMoveTo(Vector3 targetWorldPos)  
    {
        if (obstacleTilemap == null) return true;           // if no tilemap detect it returns true

        Vector3Int cellPos = obstacleTilemap.WorldToCell(targetWorldPos);       // get cellpos from worldpostition
        TileBase tile = obstacleTilemap.GetTile(cellPos);           //gets coordinates of tilemap
        return tile == null;    // if no tile then true and player moves
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameOver = true;        //if player connects with enemy , then gameover
        }
    }
}

    // ---------------------------------------------------
    // TODO: MODIFY THIS SCRIPT
    // Replace random movement with the following logic:
    // 1. Detect the player's position (use GameObject.FindWithTag("Player"))
    // 2. Compare player and enemy positions
    // 3. Move one tile horizontally OR vertically closer to the player
    // 4. Enemy should not move diagonally or through walls
    //
    // Example:
    // Vector2 playerPos = GameObject.FindWithTag("Player").transform.position;
    // Decide whether to move horizontally or vertically toward player
    // ---------------------------------------------------
