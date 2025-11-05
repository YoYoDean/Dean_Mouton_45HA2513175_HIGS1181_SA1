using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{

    //declaring variables
    Rigidbody2D rb;

    [Header("Tilemap Settings")]
    public Tilemap obsticleTilemap; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //getting player rigidbody
    }

    public void MovePlayer()
    {
        Vector3 direction = Vector3.zero; // current direction 0,0,0

        if (Keyboard.current.dKey.wasPressedThisFrame)//if input
        {
            direction = Vector3.right;//go right ,left, up ,down respectively
        }
        else if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            direction = Vector3.left;
        }
        else if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            direction = Vector3.up;
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            direction = Vector3.down;
        }

        if (direction != Vector3.zero) //if the direction is not 0,0,0 run if statement
        {
            Vector3 targetPos = rb.transform.position + direction; // set target position

            //Check if target tile is walkable before moving
            if (CanMoveTo(targetPos))
            {
                rb.MovePosition(targetPos); // move to target if able
            }
            else
            {
                rb.MovePosition(rb.transform.position + -direction); //move to opisite direction if walking into wall
                Debug.Log("Blocked! Can't move to " + targetPos);
            }
        }
    }

    private bool CanMoveTo(Vector3 targetWorldPos)
    {
        if (obsticleTilemap == null) return true; // if no tilemap detect it returns true

        Vector3Int cellPos = obsticleTilemap.WorldToCell(targetWorldPos); 
        TileBase tile = obsticleTilemap.GetTile(cellPos);//gets coordinates of tilemap

        
        return tile == null; // if no tile then true and player moves
    
    }
}
