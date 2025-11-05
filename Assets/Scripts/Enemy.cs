using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Time (in seconds) it takes to move one tile.")]
    public float moveTime = 0.2f;

    [Header("Tilemap Settings")]
    public Tilemap obstacleTilemap;

    private Rigidbody2D rb2D;
    private float inverseMoveTime;
    private Vector3 targetPosition;
    public bool gameOver;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        UIManager uIManager = GameObject.FindWithTag("UiManager").GetComponent<UIManager>();
    }

    private void Start()
    {
        inverseMoveTime = 1f / moveTime;
        targetPosition = rb2D.position;
    }

    public void TakeTurn()
    {
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
        targetPosition = playerPos - rb2D.transform.position;
        Debug.Log(targetPosition);

        Vector3 moveDir = Vector3.zero;

        if (Math.Abs(targetPosition.x) > Math.Abs(targetPosition.y))
        {
            moveDir = targetPosition.x > 0 ? Vector3.right : Vector3.left;
        }
        else
        {
            moveDir = targetPosition.y > 0 ? Vector3.up : Vector3.down;
        }

        


        if (moveDir != Vector3.zero)
        {
            Vector3 nextPos = rb2D.transform.position + moveDir;
            // Check obstacle before moving
            Debug.Log("nextpos: "  + nextPos);
            if (CanMoveTo(nextPos))
            {
                rb2D.MovePosition(nextPos);
                Debug.Log("Enemy moved.");
            }
            else
            {
                Debug.Log("Enemy blocked!");

                if (Math.Abs(targetPosition.x) > Math.Abs(targetPosition.y))
                {
                    moveDir = targetPosition.y > 0 ? Vector3.up : Vector3.down;
                    nextPos = rb2D.transform.position + moveDir;
                    rb2D.MovePosition(nextPos);
                    Debug.Log("Enemy moved.");
                }
                else
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
        if (obstacleTilemap == null) return true;

        Vector3Int cellPos = obstacleTilemap.WorldToCell(targetWorldPos);
        TileBase tile = obstacleTilemap.GetTile(cellPos);
        return tile == null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameOver = true;
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
